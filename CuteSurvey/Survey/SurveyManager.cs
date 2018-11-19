using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey
{
    public class SurveyManager
    {
        public int SurveyID{get;set;}
        public int UserID { get; set; }

        public SurveyManager(int surveyID, int userID) {
            this.SurveyID = surveyID;
            this.UserID = userID;
        }

        public SurveyManager(int surveyID) {

        }

        //public static List<int> GetEmployeeList(int surveyID) {

        //}
        
    }
}
