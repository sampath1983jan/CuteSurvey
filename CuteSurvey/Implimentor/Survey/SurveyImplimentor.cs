using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Survey;
namespace CuteSurvey.Implimentor.Survey
{
    public class SurveyImplimentor : ISurveyActions
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        Data.Survey.Survey survey;
        public SurveyImplimentor() {
            survey = new Data.Survey.Survey(conn);
        } 
        public bool Delete(int surveyID)
        {            
            if (survey.Remove(surveyID))
            {
                return true;
            }
            else return false;
           // throw new NotImplementedException();
        }

        public DataTable Load(string surveyID)
        {
            DataTable dt = new DataTable();
           dt= survey.GetSurveys(surveyID.ToString());
            return dt;            
        }

        public DataTable LoadPage(int SurveyID)
        {
            
            throw new NotImplementedException();
        }

        public bool Save(CuteSurvey.Survey.Survey survey)
        {
            throw new NotImplementedException();
        }

        public bool Update(CuteSurvey.Survey.Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
