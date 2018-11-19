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
        public int UserID { get; set; }
        public int Question { get; set; }
        public string Answer { get; set; }
        public UserAnswerHandler UserAnswerHandler { get; set; }
    }

    public interface UserAnswerHandler {
        bool Save(int questionID,int userID,string answer);
        bool Update(int questionID, int userID, string answer);
        bool clear(int questionID, int userID);
    }

   public  class UserAnswer :IUserAnswer
    {   
       public UserAnswer(){
            this.UserID = -1;
            this.Answer = "";
            this.Question = -1;
        }

        public UserAnswer(int questionID,int userID, string answer) {
            this.Question = questionID;
            this.UserID = UserID;
            this.Answer = answer;
        }

        public bool Save() {
         return   this.UserAnswerHandler.Save(this.Question, this.UserID, this.Answer);
        }

        public bool Update() {
            return this.UserAnswerHandler.Update(this.Question, this.UserID, this.Answer);
        }

        public bool Clear() {
            return this.UserAnswerHandler.clear(this.Question, this.UserID);
        }
    }
}
