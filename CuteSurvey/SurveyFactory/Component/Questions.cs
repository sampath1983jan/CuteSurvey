using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Utility;
using CuteSurvey.SurveyFactory.Component;
using System.Data;

namespace CuteSurvey.SurveyFactory.Component
{
    public interface IQuestions {
        DataTable Load(int surveyTemplateID);
        DataTable LoadChoices(int surveyTemplateID, int questionID);
        DataTable LoadCritieria(int surveyTemplateID, int questionID);
        int Save(CuteSurvey.SurveyFactory.Component.Question question);
        bool Update(CuteSurvey.SurveyFactory.Component.Question question);
        bool AddQuestion(CuteSurvey.SurveyFactory.Component.Question question);
        bool AddChoices(int surveyTemplateID,int questionID, string choices,int choiceOrder);
        bool AddCriteria(int surveyTemplateID,int questionID, string criteria,int criteriaOrder);

        bool UpdateChoice(int surveyTemplateID, int questionID,int choiceID, string choices, int choiceOrder);
        bool UpdateCriteria(int surveyTemplateID, int questionID,int criteriaID, string criteria, int criteriaOrder);

        CuteSurvey.SurveyFactory.Component.Question Duplicate(CuteSurvey.SurveyFactory.Component.Question question);
        bool Remove(int surveyTemplateID,int questionID);        
        bool Remove(CuteSurvey.SurveyFactory.Component.Question question);
        bool RemoveChoices(int surveyTemplateID, int questionID);
        bool RemoveCriterias(int surveyTemplateID, int questionID);
        bool RemoveChoice(int surveyTemplateID, int questionID,int choiceID);
        bool RemoveCriteria(int surveyTemplateID, int questionID,int CriteriaID);
    }

    public abstract class ISurveyTemplateQuestion
    {
        public IQuestions questionHandler;
        public abstract void Load();
        
    }
   public class Questions:ISurveyTemplateQuestion
    {
        /// <summary>
        ///     
        /// </summary>
        private readonly int SurveyTemplateID;
        /// <summary>
        /// 
        /// </summary>
        private QueryList<Question> QuestionList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyTemplateID"></param>
        public Questions(int surveyTemplateID) {
            SurveyTemplateID = surveyTemplateID;
            QuestionList = new QueryList<Question>();            
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Load() {
            CheckDataSecurity();
            DataTable  dt = new DataTable();
            List<Question> questions;
            dt =  questionHandler.Load(SurveyTemplateID);                   
            questions = dt.toList<Question>(new DataFieldMappings()
                  .Add("QuestionID", "QuestionID")
                  .Add("QuestionName", "QuestionName")
                  .Add("Note", "Note")
                  .Add("QuestionType", "QuestionType")
                  .Add("Description", "Comments")
                  .Add("SurveyTemplateID", "TemplateID")
                  .Add("IsRequired", "IsRequired")
                  .Add("MaxLength", "MaxLength")
                  .Add("ValidationMessage", "ValidationMessage")
                  .Add("SelectionChoice", "SelectionChoice")
                  .Add("PageNo", "PageNo")
                  .Add("enableComment", "EnableComment")
                  , null);

            foreach (Question q in questions)
            {
                q.Choices = new QuestionItem.Choices(this.SurveyTemplateID, q.QuestionID);
                q.Criterias = new QuestionItem.Criterias(this.SurveyTemplateID, q.QuestionID);
                this.AddQuestion(q);
                dt = new DataTable();
                 dt= questionHandler.LoadChoices(this.SurveyTemplateID, q.QuestionID);
               var cs= dt.toList<QuestionItem.Choice>(new DataFieldMappings()
                    .Add("SurveyTemplateID", "SurveyTemplateID")
                    .Add("QuestionID", "QuestionID")
                    .Add("ChoiceID", "ChoiceID")
                    .Add("Name", "Name")
                    .Add("OrderNo", "OrderNo")
                    , null);
                foreach (QuestionItem.Choice c in cs) {
                    q.Choices.Add(c);
                }
                dt = new DataTable();
                dt = questionHandler.LoadCritieria(this.SurveyTemplateID, q.QuestionID);
                var crs = dt.toList<QuestionItem.Criteria>(new DataFieldMappings()
                    .Add("SurveyTemplateID", "SurveyTemplateID")
                    .Add("QuestionID", "QuestionID")
                    .Add("CriteriaID", "CriteriaID")
                    .Add("Criteria", "Name")
                    .Add("OrderNo", "OrderNo")
                    , null);
                foreach (QuestionItem.Criteria  c in crs)
                {
                    q.Criterias.Add(c);
                }
            }                              
        }
        private void CheckDataSecurity() {
            if (!DataValidation())
            {
                throw new Exception("Unknow survey template");
            }
        }
        private bool  DataValidation() {
            return this.SurveyTemplateID >0 ?true:false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public  Question NewQuestion(int surveyTemplateID, SurveyQuestionType questionType,int pageNo, string choices="")
        {
            CheckDataSecurity();
            var question = CuteSurvey.SurveyFactory.Component.QuestionFactory.Create(
            new QuestionHanlderFactory(), surveyTemplateID,questionType);
            if (choices != "")
            {
                question.Choices.Add(choices.Split(Convert.ToChar(',')));
            }                
            question.PageNo = pageNo;           
            return question;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="choices"></param>
        /// <returns></returns>
        public Questions AddChoices(int questionID, string choices) {
           
            if (choices != "") {
                var a = choices.Split(Convert.ToChar(','));
                GetQuestion(questionID).Choices.Add(choices.Split(Convert.ToChar(',')));              
            }
            return this;
        }

        public bool AddChoice(int questionID, QuestionItem.Choice c) {
            CheckDataSecurity();
            if (c.ChoiceID > 0)
            {
                if (GetQuestion(questionID).Choices.isExist(c.ChoiceID))
                {
                    var gChoice = GetQuestion(questionID).Choices.getChoice(c.ChoiceID);
                    CuteSurvey.Utility.Common.Combine<QuestionItem.Choice>(ref gChoice, c);
                    return questionHandler.UpdateChoice(this.SurveyTemplateID, questionID, c.ChoiceID, c.Name, c.OrderNo);
                }
                else {
                    return questionHandler.AddChoices(this.SurveyTemplateID, questionID, c.Name, c.OrderNo);
                }
            }
            else
            {
            return questionHandler.AddChoices(this.SurveyTemplateID, questionID, c.Name, c.OrderNo);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public Questions AddCriteria(int questionID, string criteria)
        {
           
            if (criteria != "")
            {
                GetQuestion(questionID).Criterias.Add(criteria.Split(Convert.ToChar(',')));
            }
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool AddCriteria(int questionID, QuestionItem.Criteria c)
        {
            CheckDataSecurity();
            if (c.CriteriaID > 0)
            {
                if (GetQuestion(questionID).Criterias.isExist(c.CriteriaID))
                {
                    var gChoice = GetQuestion(questionID).Criterias.getCriteria(c.CriteriaID);
                    CuteSurvey.Utility.Common.Combine<QuestionItem.Criteria >(ref gChoice, c);
                    return questionHandler.UpdateCriteria(this.SurveyTemplateID, questionID, c.CriteriaID, c.Name, c.OrderNo);
                }
                else
                {
                    return questionHandler.AddCriteria(this.SurveyTemplateID, questionID, c.Name, c.OrderNo);
                }
            }
            else
            {
                return questionHandler.AddCriteria(this.SurveyTemplateID, questionID, c.Name, c.OrderNo);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public Question NewQuestionWithDefault(int surveyTemplateID,SurveyQuestionType questionType,int pageNo)
        {
            var question = QuestionFactory.Create(
            new QuestionHanlderFactory(), surveyTemplateID, questionType);
            question.PageNo = pageNo;
            return question.Default();
        }
        public Question Duplicate(int questionID)
        {
            CheckDataSecurity();
            var qust = GetQuestion(questionID).Clone();
            qust.QuestionName = "Copy of " + qust.QuestionName;
            qust.QuestionID = -1;
            var q = questionHandler.Duplicate(qust);
            if (q != null) {
                foreach (QuestionItem.Choice c in q.Choices.toList()) {
                    c.ChoiceID = -1;
                    AddChoice(q.QuestionID, c);
                }
                foreach (QuestionItem.Criteria c in q.Criterias.toList())
                {
                    c.CriteriaID = -1;
                    AddCriteria(q.QuestionID, c);
                }
            }
            return qust;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="afterRemove"></param>
        /// <returns></returns>
        public bool Remove( int questionID)
        {
            CheckDataSecurity();
            var quest = GetQuestion(questionID);
            QuestionList.Remove(quest);
            if (questionHandler.Remove(this.SurveyTemplateID, questionID)) {
                questionHandler.RemoveChoices(this.SurveyTemplateID, questionID);
                questionHandler.RemoveCriterias(this.SurveyTemplateID, questionID);
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public Question GetQuestion(int questionID)
        {
            return QuestionList.Search(x=> x.QuestionID ==questionID).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Question> GetQuestion(Func<Question, bool> search)
        {
            return QuestionList.Search(search).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool IsQuestionExist(Func<Question, bool> search)
        {
            return GetQuestion(search).Count > 0 ? true : false;
        }

        public bool Save() {
            foreach (Question q in QuestionList.toList()) {
                Save(q);

            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="Save"></param>
        /// <returns></returns>
        private bool Save(Question question)
        {
            CheckDataSecurity();
            //check Question Exist or not then update;
            if (IsQuestionExist(x => x.QuestionID == question.QuestionID))
            {
                var gQuestion = GetQuestion(question.QuestionID);
                CuteSurvey.Utility.Common.Combine<Question>(ref gQuestion, question);
                if (questionHandler.Update(question))
                {
                    foreach (QuestionItem.Choice c in question.Choices.toList())
                    {
                        this.AddChoice(question.QuestionID, c);
                    }
                    return true;
                }
                else return false; 
            }
            else
            {
                QuestionList.Add(question);
                int key = questionHandler.Save(question);
                question.QuestionID = key;
                if (key >0)
                {
                    foreach (QuestionItem.Choice c in question.Choices.toList())
                    {
                        questionHandler.AddChoices(this.SurveyTemplateID, -1, c.Name, c.OrderNo);
                    }
                    return true;
                }
            }            
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="Save"></param>
        /// <returns></returns>
        public bool AddQuestion(Question question)
        {
            //check Question Exist or not then update;
            if (IsQuestionExist(x => x.QuestionID == question.QuestionID))
            {
                var gQuestion = GetQuestion(question.QuestionID);
                CuteSurvey.Utility.Common.Combine<Question>(ref gQuestion, question);
            }
            else
            {
                QuestionList.Add(question);
            }                       
            return true;            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="Delete"></param>
        /// <returns></returns>        
        public bool Remove(Question question)
        {
            CheckDataSecurity();
            QuestionList.Remove(question);
            if (questionHandler.Remove(this.SurveyTemplateID, question.QuestionID))
            {
                questionHandler.RemoveChoices(this.SurveyTemplateID, question.QuestionID);
                questionHandler.RemoveCriterias(this.SurveyTemplateID, question.QuestionID);
                return true;
            }
            else return false;           
        }               

    }
}
