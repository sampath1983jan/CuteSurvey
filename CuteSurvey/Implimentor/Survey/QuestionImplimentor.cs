using CuteSurvey.SurveyFactory.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Implimentor.Survey
{
    public class QuestionImplimentor : CuteSurvey.Survey.IQuestionsHandler
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        Data.Survey.Question dataQuestion;
        Data.Survey.Choices dataChoice;
        Data.Survey.Critieria dataCritieria;
      
        public QuestionImplimentor(){
            dataQuestion = new Data.Survey.Question(conn);
            dataChoice = new Data.Survey.Choices(conn);
            dataCritieria = new Data.Survey.Critieria(conn);
        }
        
        public bool AddChoices(int surveyID, int questionID, string choices, int choiceOrder)
        {
             return dataChoice.Save(surveyID, questionID, choices, choiceOrder);
          //  throw new NotImplementedException();
        }

        public bool AddCriteria(int surveyID, int questionID, string criteria, int criteriaOrder)
        {
            return dataCritieria.Save(surveyID, questionID, criteria, criteriaOrder);
          //  throw new NotImplementedException();
        }

        public bool AddQuestion(CuteSurvey.Survey.Question question)
        {          
          throw new NotImplementedException();
        }
             

        public DataTable Load(int surveyID)
        {
            return dataQuestion.GetQuestions(surveyID);
            //throw new NotImplementedException();
        }

        public DataTable LoadChoices(int surveyID, int questionID)
        {
            return dataChoice.GetChoices(surveyID, questionID);
            //throw new NotImplementedException();
        }

        public DataTable LoadCritieria(int surveyID, int questionID)
        {
            return dataCritieria.GetCriteria(surveyID, questionID);
            //throw new NotImplementedException();
        }
        public bool RemoveAll(int surveyID)
        {
            return dataQuestion.RemoveAll(surveyID);
        }

        public bool Remove(int surveyID, int questionID)
        {
            return dataQuestion.Remove(surveyID, questionID);                        
        }

        public bool Remove(CuteSurvey.Survey.Question question)
        {
            return dataQuestion.Remove(question.TemplateID, question.QuestionID);
            //throw new NotImplementedException();
        }

        public bool RemoveChoice(int surveyID, int questionID, int choiceID)
        {
            return dataChoice.Remove(surveyID, questionID, choiceID);
            //throw new NotImplementedException();
        }

        public bool RemoveAllChoices(int surveyID)
        {
            return dataChoice.RemoveAll(surveyID);
            //throw new NotImplementedException();
        }

        public bool RemoveChoices(int surveyID, int questionID)
        {
            return dataChoice.RemoveAll(surveyID, questionID);
            //throw new NotImplementedException();
        }               

        public bool RemoveCriteria(int surveyID, int questionID, int CriteriaID)
        {
            return dataCritieria.Remove(surveyID, questionID, CriteriaID);
        }

        public bool RemoveCriterias(int surveyID, int questionID)
        {
            return dataCritieria.RemoveAll(surveyID, questionID);                    
        }

        public int Save( CuteSurvey.Survey.Question question)
        {
            return dataQuestion.Save(question.TemplateID, question.QuestionName, question.Comments, (int)question.QuestionType, question.Note,
              question.IsRequired, question.MaxLength, (int)question.SelectionChoice, question.EnableComment, question.PageNo, question.ValidationMessage);
         
        }

        public bool Update(CuteSurvey.Survey.Question question)
        {
            return dataQuestion.Update(question.TemplateID, question.QuestionID, question.QuestionName, question.Comments, question.Note,
                question.IsRequired, question.MaxLength, (int)question.SelectionChoice, question.EnableComment, question.PageNo,
                question.ValidationMessage);
         
        }

        public bool UpdateChoice(int surveyID, int questionID, int choiceID, string choices, int choiceOrder)
        {
            return dataChoice.Update(surveyID, questionID,choiceID, choices, choiceOrder);
         
        }

        public bool UpdateCriteria(int surveyID, int questionID, int criteriaID, string criteria, int criteriaOrder)
        {
            return dataCritieria.Update(surveyID, questionID, criteriaID, criteria, criteriaOrder);
         
        }

        public bool RemoveAllCriterias(int surveyID)
        {
            return dataCritieria.RemoveAll(surveyID);
        }

        
    }
}
