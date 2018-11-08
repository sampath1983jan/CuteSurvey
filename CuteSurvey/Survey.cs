using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory
{
    public enum SurveyStatus
    {
        _notstarted = 0,
        _progress = 1,
        _completed = 2
    }
    public class Survey
    {
        public int SurveyID;
        public ISurveyTemplate Template;
        public DateTime StartDate;
        public DateTime EndDate;
        public SurveyStatus Status;
        public Survey(int surveyID)
        {
            SurveyID = surveyID;
            Status = SurveyStatus._notstarted;
            Template = new SurveyTemplate(-1);            
        }
    }
}
