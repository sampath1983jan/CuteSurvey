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

    public interface IQuestionAction
    {
        bool Save();
        bool Update();
        bool Delete();
        bool Validation();
    }

    public class Question : CuteSurvey.SurveyFactory.Component.Question 
    {                     
        public int SurveyID { get; set; }
        public override SurveyFactory.Component.Question Clone()
        {
            throw new NotImplementedException();
        }

        public override SurveyFactory.Component.Question Default()
        {
            throw new NotImplementedException();
        }

        public Question(int surveyID) : base(surveyID) {
            this.SurveyID = surveyID;
        }
    }

    public class Questions : CuteSurvey.SurveyFactory.Component.Questions {
        public int SurveyID { set; get; }
        public Questions(int surveyID) : base(surveyID) {
            this.SurveyID = surveyID;
        }
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
    }


}
