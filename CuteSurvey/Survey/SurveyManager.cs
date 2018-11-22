using CuteSurvey.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey
{

    public abstract class SurveyManagerProvider {
       public Survey Survey;
        public List<SurveyUser> surveyUsers;
        public ISurveyManagerHandler SurveyManagerHandler;        
    }

    public interface ISurveyManagerHandler {
        DataTable LoadUser(int surveyID);
        DataTable LoadUserAnswer(int surveyID, int userID);
        bool SaveAnswer(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments);
        bool UpdateAnswer(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments);
        bool ClearAnswer(int surveyID, int questionID, int userID);
        bool AssigeUser(int surveyID, int userID, UserSurveyStatus userSurveyStatus );
        bool RemoveUser(int surveyID, int userID);
    }
    public class SurveyManager : SurveyManagerProvider
    {
        private int SurveyID { get; set; }
        private int UserID { get; set; }

        public List<SurveyUser> newsurveyUsers;

        public SurveyManager(int surveyID, int userID)
        {
            this.SurveyID = surveyID;
            this.UserID = userID;
            newsurveyUsers = new List<SurveyUser>();
            LoadUser();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyID"></param>
        public SurveyManager(int surveyID)
        {
            newsurveyUsers = new List<SurveyUser>();
            this.SurveyID = surveyID;
            Survey = new Survey(this.SurveyID);            
            LoadUser();
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadUser()
        {
            DataTable dt = new DataTable();
            dt = this.SurveyManagerHandler.LoadUser(this.SurveyID);
            surveyUsers = dt.toList<SurveyUser>(new DataFieldMappings()
                .Add("UserID", "UserID")
                .Add("SurveyID", "SurveyID")
                .Add("Status", "Status"),
                null).ToList();
        }
        /// <summary>
        /// Add user to the survey using survey manager once added user then you must call SaveUser function. 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public SurveyManager AddUser(int userID) {
            newsurveyUsers.Add(new SurveyUser(this.SurveyID,userID));
            return this;
        }
        public bool SaveUser() {
            foreach (SurveyUser su in this.newsurveyUsers) {
                this.SurveyManagerHandler.AssigeUser(this.SurveyID, su.UserID,su.Status);
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>        /// 
        public bool RemoveUser() {
            var su = this.surveyUsers.Where(x => x.UserID == this.UserID).First();
            if (su != null)
            {
                return this.SurveyManagerHandler.RemoveUser(this.SurveyID, this.UserID);
            }
            else return false;            
        }                        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SurveyUser GetUserAnswer()
        {
            var su = this.surveyUsers.Where(x => x.UserID == this.UserID).FirstOrDefault();
            su.UserAnswers = GetUserAnswer(UserID);
            return su;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        public bool SaveAnswer(int userID, UserAnswer userAnswer) {             
            userAnswer.UserAnswerHandler = new UserAnswerImpliementation(this);            
            var UserAnswers = GetUserAnswer(userID);
            if (UserAnswers.Where(x => x.Question == userAnswer.Question && x.UserID == userID).ToList().Count > 0) {
                userAnswer.Update();
            }else userAnswer.Save();
            

            return true;
        }
        public bool Clear(UserAnswer userAnswer) {
            userAnswer.UserAnswerHandler = new UserAnswerImpliementation(this);
            return userAnswer.Clear();
        }
        public List<UserAnswer> GetUserAnswer(int UserID)
        {
            DataTable dt = new DataTable();
            dt = this.SurveyManagerHandler.LoadUserAnswer(this.SurveyID, UserID);
            return dt.toList<UserAnswer>(new DataFieldMappings()
                .Add("UserID", "UserID")
                .Add("QuestionID", "Question")
                 .Add("Answer", "Answer")
                .Add("ChoiceID", "ChoiceID")
                 .Add("CriteriaID", "CriteriaID"),
                null).ToList();
        }
    }

    internal class UserAnswerImpliementation : UserAnswerHandler
    {
        private SurveyManager Survey;
        public UserAnswerImpliementation(SurveyManager s) {
            Survey = s;
        }

        public bool clear(int surveyID, int questionID, int userID)
        {
            return Survey.SurveyManagerHandler.ClearAnswer(surveyID, questionID, userID);
        }

        public bool Save(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments)
        {
            return Survey.SurveyManagerHandler.SaveAnswer(surveyID, questionID, userID, choiceID, criteriaID, answer, comments);
        }

        public bool Update(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments)
        {
            return Survey.SurveyManagerHandler.SaveAnswer(surveyID, questionID, userID, choiceID, criteriaID, answer, comments);
        }
    }
}
