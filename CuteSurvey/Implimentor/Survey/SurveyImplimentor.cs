using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Survey;
namespace CuteSurvey.Implimentor.Survey
{
    public class SurveyImplimentor : ISurveyHandler
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        Data.Survey.Survey dataSurvey;
        public SurveyImplimentor() {
            dataSurvey = new Data.Survey.Survey(conn);
        }

        public bool ChangeEndDate(int surveyID, DateTime endDate)
        {
            return dataSurvey.ChangeEndDate(surveyID, endDate);
        }

        public bool ChangeStatus(int surveyID, int status)
        {
            return dataSurvey.ChangeStatus(surveyID, status);
        }

        public bool Delete(int surveyID)
        {            
            if (dataSurvey.Remove(surveyID))
            {
                return true;
            }
            else return false;           
        }

        public DataTable Load(string surveyID)
        {
            DataTable dt = new DataTable();
           dt= dataSurvey.GetSurveys(surveyID.ToString());
            return dt;            
        }

        public DataTable LoadPage(int SurveyID)
        {            
            Data.Survey.Page pg = new Data.Survey.Page(conn);
           return  pg.GetPages(SurveyID);           
        }

        public int Save(CuteSurvey.Survey.Survey survey)
        {
           return dataSurvey.SaveSurvey(survey.SurveyTemplateID, survey.StartDate, survey.EndDate, survey.Name, survey.Description,
                survey.Description, survey.IntroductionNote, survey.ThanksNote, (int)survey.Status);            
        }

        public bool Update(CuteSurvey.Survey.Survey survey)
        {
        return    dataSurvey.UpdateSurvey(survey.SurveyID, survey.Name, survey.Description, survey.Category, survey.IntroductionNote, survey.ThanksNote, survey.StartDate, survey.EndDate);
        }
    }
}
