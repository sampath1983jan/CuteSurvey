using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory;
namespace CuteSurvey.Survey.Question
{
    public class Choice: SurveyFactory.Component.QuestionItem.Choice 
    {
        public int SurveyID { get; set; }
        public Choice(int surveyID,int questionID)
        {
            SurveyID = surveyID;
            QuestionID = questionID;
        }        
    }

    public class Choices:SurveyFactory.Component.QuestionItem.Choices {
        public int SurveyID { get; set; }
        public Choices(int surveyID, int questionID):base(surveyID,questionID) {
            SurveyID = surveyID;
        }
    }
}


