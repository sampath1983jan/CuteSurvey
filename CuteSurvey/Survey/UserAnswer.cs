using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Survey;
using CuteSurvey.SurveyFactory.Component;

namespace CuteSurvey.Survey
{
    public class IUserAnswer {
        public int SurveyID { get; set; }
        public int UserID { get; set; }
        public int Question { get; set; }
        public string Answer { get; set; }
        public string Comments { get; set; }
        public int ChoiceID { get; set; }
        public int CriteriaID { get; set; }
        public UserAnswerHandler UserAnswerHandler { get; set; }        
    }

    public interface UserAnswerHandler {
        bool Save(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments);
        bool Update(int surveyID, int questionID, int userID, int choiceID, int criteriaID, string answer, string comments);
        bool clear(int surveyID, int questionID, int userID);
    }

   public  class UserAnswer :IUserAnswer
    {   
       public UserAnswer(){
            this.UserID = -1;
            this.Answer = "";
            this.Question = -1;
            this.SurveyID = -1 ;
            this.CriteriaID = -1;
            this.ChoiceID = -1;
            this.Comments = "";
        }

        public UserAnswer(int surveyID,int questionID, int userID, int choiceID, int criteriaID, string answer, string comments) {
            this.Question = questionID;
            this.UserID = UserID;
            this.Answer = answer;
            this.CriteriaID = criteriaID;
            this.ChoiceID = choiceID;
            this.Comments = comments;
            this.SurveyID = surveyID;
        }

        public bool isAnswered() {
            if (this.Answer != "")
            {
                return true;
            }
            else if (this.ChoiceID > 0 && (this.CriteriaID > 0))
            {
                return true;
            }
            else if (this.ChoiceID > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Save() {
         return   this.UserAnswerHandler.Save(this.SurveyID,this.Question,this.UserID,this.ChoiceID,this.CriteriaID,this.Answer,this.Comments);
        }

        public bool Update() {
            return this.UserAnswerHandler.Update(this.SurveyID, this.Question, this.UserID, this.ChoiceID, this.CriteriaID, this.Answer, this.Comments);
        }

        public bool Clear() {
            return this.UserAnswerHandler.clear(this.SurveyID, this.Question, this.UserID);
        }
    }
}
