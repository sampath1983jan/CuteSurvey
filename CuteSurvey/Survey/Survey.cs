using CuteSurvey.SurveyFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey
{
    public enum SurveyStatus
    {
        _notstarted = 0,
        _progress = 1,
        _completed = 2
    }
    public interface ISurvey{
         int SurveyID { get; set; }
         ISurveyTemplate Template { get; set; }
         DateTime StartDate { get; set; }
         DateTime EndDate { get; set; }
         SurveyStatus Status { get; set; }
         void Load();
        bool Save();
    }
    [Serializable]
    public class Survey:ISurvey

    {
        private int surveyID;
        private ISurveyTemplate template;
        private DateTime startDate;
        private DateTime endDate;
        private SurveyStatus status;

        public int SurveyID { get => surveyID; set => surveyID=value; }
        public ISurveyTemplate Template { get => template; set => template = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public SurveyStatus Status { get => status; set => status=value; }

        public Survey()
        {

        }        
        public Survey(int templateID, DateTime startDate, DateTime endDate) {
            Status = SurveyStatus._notstarted;
            Template = new SurveyTemplate(templateID);
            StartDate = startDate;
            EndDate = endDate;
        }
                 
        public void Load()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
    
}
