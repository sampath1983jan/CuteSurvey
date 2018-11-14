using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey;
namespace CuteSurvey.Survey.QuestionItem
{
    public class Criteria:SurveyFactory.Component.QuestionItem.Criteria 
    {
        public int SurveyID { get; set; }
        public Criteria(int surveyID,int questionID) {
            SurveyID = surveyID;
            QuestionID= questionID;
        }
    }

    public class Criterias : SurveyFactory.Component.QuestionItem.Criterias {
        public int SurveyID { get; set; }
        public Criterias(int surveyID, int questionID) : base(surveyID, questionID) {
            this.SurveyID = surveyID;            
        }       
    }
}
