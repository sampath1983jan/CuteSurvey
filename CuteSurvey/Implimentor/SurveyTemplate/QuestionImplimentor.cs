using System;
using System.Collections.Generic;
using CuteSurvey.Survey;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory.Component.QuestionType;
using System.Dynamic;
using System.ComponentModel;
using CuteSurvey.SurveyFactory.Component;
using System.Data;
using CuteSurvey.Utility;
namespace CuteSurvey.Implimentor
{
    public class QuestionImplimentor: IQuestionsHandler
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        Data.Questions qust;
        
        public bool AddChoices(int surveyTemplateID,int questionID, string choices, int choiceOrder)
        {
            Data.QuestionChoices qc = new Data.QuestionChoices(conn);
            return qc.Save(surveyTemplateID, questionID, choices, choiceOrder);
        }

        public bool AddCriteria(int surveyTemplateID,int questionID, string criteria, int criteriaOrder)
        {
            Data.QuestionCriteria qc = new Data.QuestionCriteria(conn);
            if (qc.Save(surveyTemplateID, questionID, criteria, criteriaOrder))
            {
                return true;
            }
            else return false;
        }
        public bool AddQuestion(CuteSurvey.SurveyFactory.Component.Question question)
        {
            throw new NotImplementedException();
        }
        public CuteSurvey.SurveyFactory.Component.Question Duplicate(CuteSurvey.SurveyFactory.Component.Question question)
        {
            int key = Save(question);
            if (key >0)
            {
                question.QuestionID = key;
                return question;
            }
            else return null;            
        }
        public DataTable Load(int surveyTemplateID)
        {
            DataTable dt = new DataTable();
              qust = new Data.Questions(conn);
            dt = qust.GetQuestions(surveyTemplateID);
            return dt;
        }

        public DataTable LoadChoices(int surveyTemplateID, int questionID)
        {
            Data.QuestionChoices qc = new Data.QuestionChoices(conn);
            return qc.GetChoices(surveyTemplateID, questionID);
        }

        public DataTable LoadCritieria(int surveyTemplateID, int questionID)
        {
            Data.QuestionCriteria qc = new Data.QuestionCriteria(conn);
           return qc.GetCriteria(surveyTemplateID, questionID);
        }

        public bool Remove(int surveyTemplateID,int questionID)
        {
            qust = new Data.Questions(conn);
            return qust.Remove(surveyTemplateID, questionID);
        }

        public bool Remove(CuteSurvey.SurveyFactory.Component.Question question)
        {
            qust = new Data.Questions(conn);
           return qust.Remove(question.TemplateID, question.QuestionID);           
        }

        public bool RemoveAll(int templateID)
        {
            qust = new Data.Questions(conn);
            return qust.RemoveAll(templateID);
        //    throw new NotImplementedException();
        }

        public bool RemoveChoice(int surveyTemplateID, int questionID, int choiceID)
        {
            Data.QuestionChoices qc = new Data.QuestionChoices(conn);
            return qc.Remove(surveyTemplateID, questionID, choiceID);
        }

        public bool RemoveChoices(int surveyTemplateID, int questionID)
        {
            Data.QuestionChoices qc = new Data.QuestionChoices(conn);
            return qc.RemoveAll(surveyTemplateID, questionID);
        }

        public bool RemoveCriteria(int surveyTemplateID, int questionID, int CriteriaID)
        {
            Data.QuestionCriteria qc = new Data.QuestionCriteria(conn);
            return qc.Remove(surveyTemplateID, questionID, CriteriaID);
        }

        public bool RemoveCriterias(int surveyTemplateID, int questionID)
        {
            Data.QuestionCriteria qc = new Data.QuestionCriteria(conn);
            return qc.RemoveAll(surveyTemplateID, questionID);
        }

        public int Save(CuteSurvey.SurveyFactory.Component.Question question)
        {
            qust = new Data.Questions(conn);
           return qust.Save(question.TemplateID, question.QuestionName, question.Comments, (int)question.QuestionType, question.Note, question.IsRequired,
                question.MaxLength, (int)question.SelectionChoice, question.EnableComment, question.PageNo,question.ValidationMessage );                                   
        }

        public bool Update(CuteSurvey.SurveyFactory.Component.Question question)
        {
            qust = new Data.Questions(conn);
            return qust.Update(question.TemplateID, question.QuestionID, question.QuestionName, question.Comments, question.Note, question.IsRequired,
                question.MaxLength, (int)question.SelectionChoice, question.EnableComment, question.PageNo, question.ValidationMessage);
        }

        public bool UpdateChoice(int surveyTemplateID, int questionID, int choiceID, string choices, int choiceOrder)
        {
            Data.QuestionChoices ac = new Data.QuestionChoices(conn);
            return ac.Update(surveyTemplateID, questionID, choiceID, choices, choiceOrder);
        }

        public bool UpdateCriteria(int surveyTemplateID, int questionID, int criteriaID, string criteria, int criteriaOrder)
        {
            Data.QuestionCriteria ac = new Data.QuestionCriteria(conn);
            return ac.Update(surveyTemplateID, questionID, criteriaID, criteria, criteriaOrder);
        }
    }
}
