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

   public class UserSurvey
    {
        public int SurveyID { get; set; }
        public int UserID { get; set; }
        public UserSurveyStatus Status { get; set; }
    }
}
