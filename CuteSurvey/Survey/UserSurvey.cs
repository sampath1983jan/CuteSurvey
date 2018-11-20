using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey
{
    public enum UserSurveyStatus {
        _pending=0,
        _progress=1,
        _done=2
    }

   public class SurveyUser
    {
        public int SurveyID { get; set; }
        public int UserID { get; set; }
        public UserSurveyStatus Status { get; set; }
        public List<UserAnswer> UserAnswers;

        public SurveyUser(int surveyID, int userID) {
            this.SurveyID = surveyID;
            this.UserID = UserID;
            this.Status = UserSurveyStatus._pending;
        }

        public SurveyUser() {
            this.SurveyID = -1;
            this.UserID = -1;
            this.Status = UserSurveyStatus._pending;
        }

         


    }
}
