using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Utility;
using CuteSurvey.SurveyFactory.Component;
namespace CuteSurvey.SurveyFactory.Component
{
   public class Questions
    {
        /// <summary>
        /// 
        /// </summary>
        private int SurveyTemplateID;
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
        /// <param name="questionType"></param>
        /// <returns></returns>
        public Question NewQuestion(SurveyQuestionType questionType,int pageNo, string choices="")
        {
            var question = CuteSurvey.SurveyFactory.Component.QuestionFactory.Create(
            new QuestionHanlderFactory(), questionType);
            if (choices != "")
            {
                question.choices.Add(choices.Split(Convert.ToChar(',')));
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
                GetQuestion(questionID).choices.Add(choices.Split(Convert.ToChar(',')));
            }            
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public Question NewQuestionWithDefault(SurveyQuestionType questionType,int pageNo)
        {
            var question = QuestionFactory.Create(
            new QuestionHanlderFactory(), questionType);
            question.PageNo = pageNo;
            return question.Default();
        }
        public Question Duplicate(int questionID)
        {
            var qust = GetQuestion(questionID).Clone();
            qust.QuestionName = "Copy of " + qust.QuestionName;
            qust.QuestionID = -1;
            return qust;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="afterRemove"></param>
        /// <returns></returns>
        public bool Remove(int questionID, Func<Question, bool> afterRemove)
        {
            var quest = GetQuestion(questionID);
            QuestionList.Remove(quest);
            afterRemove(quest);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="Save"></param>
        /// <returns></returns>
        public bool AddQuestion(Question question, Func<Question, bool> Save)
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
            return Save(question);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="Delete"></param>
        /// <returns></returns>        
        public bool Remove(Question question, Func<IQuestion, bool> Delete)
        {
            QuestionList.Remove(question);
            return Delete(question);
        }

        public Questions UpdateKey()
        {
            foreach (Question i in QuestionList.toList())
            {
                i.TemplateIID = SurveyTemplateID;
            }
            return this;
        }

    }
}
