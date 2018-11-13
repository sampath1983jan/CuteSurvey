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
    public class QuestionImplimentor: IQuestions
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        Data.Questions qust;
        public Questions AddChoices(int questionID, string choices)
        {
            throw new NotImplementedException();
        }

        public Questions AddCriteria(int questionID, string criteria)
        {
            throw new NotImplementedException();
        }

        public bool AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Question Duplicate(Question question)
        {
            if (Save(question))
            {
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

        public bool Remove(int questionID)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Question question)
        {
            qust = new Data.Questions(conn);
           return qust.Remove(question.TemplateID, question.QuestionID);           
        }

        public bool Save(Question question)
        {
            qust = new Data.Questions(conn);
           return qust.Save(question.TemplateID, question.QuestionName, question.Comments, (int)question.QuestionType, question.Note, question.IsRequired,
                question.MaxLength, (int)question.SelectionChoice, question.EnableComment, question.PageNo,question.ValidationMessage );                                   
        }

        public bool Update(Question question)
        {
            qust = new Data.Questions(conn);
            return qust.Update(question.TemplateID, question.QuestionID, question.QuestionName, question.Comments, question.Note, question.IsRequired,
                question.MaxLength, (int)question.SelectionChoice, question.EnableComment, question.PageNo, question.ValidationMessage);
        }
    }
}
