using CuteSurvey.Survey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Implimentor.Survey
{
    public class SurveyManagerImplimentor : ISurveyManagerHandler
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        CuteSurvey.Data.Survey.SurveyUser dataSurveyUser;
        CuteSurvey.Data.Survey.UserAnswer dataUserAns;
        public SurveyManagerImplimentor() {
              dataSurveyUser = new Data.Survey.SurveyUser(conn);
             dataUserAns = new Data.Survey.UserAnswer(conn);
        } 
        public bool AssigeUser(int surveyID, int userID, UserSurveyStatus userSurveyStatus)
        {
        dataSurveyUser.AddUser(surveyID, userID, (int)userSurveyStatus);
          return  dataSurveyUser.SaveUser();
        }

        public bool ClearAnswer(int surveyID, int questionID, int userID)
        {
            throw new NotImplementedException();
        }

        public DataTable LoadUser(int surveyID)
        {
            return dataSurveyUser.GetSurveyUserList(surveyID);
        }

        public DataTable LoadUserAnswer(int surveyID, int userID)
        {
            return dataUserAns.GetSurveyQuestionAnswer(surveyID, userID);
        }

        public bool RemoveUser(int surveyID, int userID)
        {
            return dataSurveyUser.RemoveUser(surveyID, userID);
        }

        public bool SaveAnswer(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments)
        {
            return dataUserAns.SaveQuestionAnswer(surveyID, userID, questionID, choiceID, criteriaID, answer, comments);
        }

        public bool UpdateAnswer(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments)
        {
            return dataUserAns.UpdateQuestionAnswer(surveyID, userID, questionID, choiceID, criteriaID, answer, comments);
        }
    }
}
