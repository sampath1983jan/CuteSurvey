using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory.Component;
using CuteSurvey.Survey.QuestionItem;
using System.Data;
using CuteSurvey.Utility;
namespace CuteSurvey.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestionAction
    {
        bool Save();
        bool Update();
        bool Delete();
        bool Validation();
    }
    /// <summary>
    /// 
    /// </summary>
    public class Question : IQuestion
    {                     
        public int SurveyID { get; set; }
        private int templateID;
        private int questionID;
        private string questionName;
        private string note;
        private string comments;
        SelectionChoice selectionChoice;
        private bool isRequired;
        private int maxLength;
        private string validationMessage;
        private int pageNo;
        private bool enableComment;
        
        public SurveyQuestionType QuestionType { get; set; }
        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionName { get => questionName; set => questionName = value; }
        public string Note { get => note; set => note = value; }
        public string Comments { get => comments; set => comments = value; }
        public int TemplateID { get => templateID; set => templateID = value; }
        public bool IsRequired { set => isRequired = value; get => isRequired; }
        public int MaxLength { set => maxLength = value; get => maxLength; }
        public string ValidationMessage { set => validationMessage = value; get => validationMessage; }
        public SelectionChoice SelectionChoice { set => selectionChoice = value; get => selectionChoice; }
        public int PageNo { get => pageNo; set => pageNo = value; }
        public bool EnableComment { get => enableComment; set => enableComment = value; }

        public Choices Choices { get; set; }
        public Criterias Criterias { get; set; }

        public Question(int surveyID)  {
            this.SurveyID = surveyID;
        }

        public SurveyFactory.Component.Question Default()
        {
            throw new NotImplementedException();
        }
    }

    public interface IQuestionsHandler
    {
        DataTable Load(int surveyID);
        DataTable LoadChoices(int surveyID, int questionID);
        DataTable LoadCritieria(int surveyID, int questionID);
        int Save(Question question);
        bool Update(Question question);
        bool AddQuestion(Question question);
        bool AddChoices(int surveyID, int questionID, string choices, int choiceOrder);
        bool AddCriteria(int surveyID, int questionID, string criteria, int criteriaOrder);

        bool UpdateChoice(int surveyID, int questionID, int choiceID, string choices, int choiceOrder);
        bool UpdateCriteria(int surveyID, int questionID, int criteriaID, string criteria, int criteriaOrder);

       // CuteSurvey.SurveyFactory.Component.Question Duplicate(Question question);
        bool Remove(int SurveyID, int questionID);
        bool RemoveAll(int templateID);
        bool Remove(Question question);
        bool RemoveAllChoices(int SurveyID);
        bool RemoveChoices(int SurveyID, int questionID);
        bool RemoveCriterias(int SurveyID, int questionID);
        bool RemoveAllCriterias(int SurveyID);
        bool RemoveChoice(int SurveyID, int questionID, int choiceID);
        bool RemoveCriteria(int SurveyID, int questionID, int CriteriaID);
    }

    public abstract class ISurveyTemplateQuestion
    {
        public IQuestionsHandler questionHandler;
        public abstract void Load();
        public abstract bool Save();

    }
    /// <summary>
    /// 
    /// </summary>
    public class Questions : ISurveyTemplateQuestion
    {
        /// <summary>
        /// 
        /// </summary>
        public int SurveyID { set; get; }
        private QueryList<Question> QuestionList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyID"></param>
        public Questions(int surveyID) {
            this.SurveyID = surveyID;
            QuestionList = new QueryList<Question>();
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {                       
             DataTable dt = new DataTable();
            List<Question> questions;
            dt = questionHandler.Load(this.SurveyID);
            questions = dt.toList<Question>(new DataFieldMappings()
                  .Add("QuestionID", "QuestionID")
                  .Add("QuestionName", "QuestionName")
                  .Add("Note", "Note")
                  .Add("QuestionType", "QuestionType")
                  .Add("Description", "Comments")
                   .Add("SurveyID", "SurveyID")
                  .Add("IsRequired", "IsRequired")
                  .Add("MaxLength", "MaxLength")
                  .Add("ValidationMessage", "ValidationMessage")
                  .Add("SelectionChoice", "SelectionChoice")
                  .Add("PageNo", "PageNo")
                  .Add("enableComment", "EnableComment")
                  , null);
            foreach (Question q in questions)
            {
                q.Choices = new QuestionItem.Choices(this.SurveyID, q.QuestionID);
                q.Criterias = new QuestionItem.Criterias(this.SurveyID, q.QuestionID);
                this.AddQuestion(q);
                dt = new DataTable();
                dt = questionHandler.LoadChoices(this.SurveyID, q.QuestionID);
                var cs = dt.toList<QuestionItem.Choice>(new DataFieldMappings()
                     .Add("SurveyID", "SurveyID")
                     .Add("QuestionID", "QuestionID")
                     .Add("ChoiceID", "ChoiceID")
                     .Add("Name", "Name")
                     .Add("OrderNo", "OrderNo")
                     , null);
                foreach (QuestionItem.Choice c in cs)
                {
                    q.Choices.Add(c);
                }
                dt = new DataTable();
                dt = questionHandler.LoadCritieria(this.SurveyID, q.QuestionID);
                var crs = dt.toList<QuestionItem.Criteria>(new DataFieldMappings()
                   // .Add("SurveyTemplateID", "SurveyTemplateID")
                    .Add("SurveyID", "SurveyID")
                    .Add("QuestionID", "QuestionID")
                    .Add("CriteriaID", "CriteriaID")
                    .Add("Criteria", "Name")
                    .Add("OrderNo", "OrderNo")
                    , null);
                foreach (QuestionItem.Criteria c in crs)
                {
                    q.Criterias.Add(c);
                }
            }

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
        /// <param name="questionType"></param>
        /// <returns></returns>
        public Question NewQuestion(int surveyID, SurveyQuestionType questionType, int pageNo, string choices = "")
        {
            //    CheckDataSecurity();
            var question = new Question(this.SurveyID);
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
        public Questions AddChoices(int questionID, string choices)
        {

            if (choices != "")
            {
                var a = choices.Split(Convert.ToChar(','));
                GetQuestion(questionID).Choices.Add(choices.Split(Convert.ToChar(',')));
            }
            return this;
        }

        public bool AddChoice(int questionID, QuestionItem.Choice c)
        {
            
            if (c.ChoiceID > 0)
            {
                if (GetQuestion(questionID).Choices.isExist(c.ChoiceID))
                {
                    var gChoice = GetQuestion(questionID).Choices.getChoice(c.ChoiceID);
                    CuteSurvey.Utility.Common.Combine<QuestionItem.Choice>(ref gChoice, c);
                    return questionHandler.UpdateChoice(this.SurveyID, questionID, c.ChoiceID, c.Name, c.OrderNo);
                }
                else
                {
                    return questionHandler.AddChoices(this.SurveyID, questionID, c.Name, c.OrderNo);
                }
            }
            else
            {
                return questionHandler.AddChoices(this.SurveyID, questionID, c.Name, c.OrderNo);
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
             
            if (c.CriteriaID > 0)
            {
                if (GetQuestion(questionID).Criterias.isExist(c.CriteriaID))
                {
                    var gChoice = GetQuestion(questionID).Criterias.getCriteria(c.CriteriaID);
                    CuteSurvey.Utility.Common.Combine<QuestionItem.Criteria>(ref gChoice, c);
                    return questionHandler.UpdateCriteria(this.SurveyID, questionID, c.CriteriaID, c.Name, c.OrderNo);
                }
                else
                {
                    return questionHandler.AddCriteria(this.SurveyID, questionID, c.Name, c.OrderNo);
                }
            }
            else
            {
                return questionHandler.AddCriteria(this.SurveyID, questionID, c.Name, c.OrderNo);
            }
        }

        public Question GetQuestion(int questionID)
        {
            return QuestionList.Search(x => x.QuestionID == questionID).FirstOrDefault();
        }

         
        public bool Save(Question question) {
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
                if (key > 0)
                {
                    foreach (QuestionItem.Choice c in question.Choices.toList())
                    {
                        questionHandler.AddChoices(this.SurveyID, -1, c.Name, c.OrderNo);
                    }
                    return true;
                }
            }
            return true;
        }
        public override bool Save()
        {
            foreach (Question q in QuestionList.toList())
            {
                Save(q);

            }
            return true;
        }


        public bool RemoveAll() {
            if (this.questionHandler.RemoveAll(this.SurveyID)) {               
                this.questionHandler.RemoveAllChoices(this.SurveyID);
                this.questionHandler.RemoveAllCriterias(this.SurveyID);                
            } return true;
        }
    }


}
