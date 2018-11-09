using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Utility;
namespace CuteSurvey.SurveyFactory.Component.Utility
{
    public class Choice
    {
        public string Name;
        public int OrderNo;        
        public int ChoiceID;
        public int QuestionID;
        public Choice(int choiceID,int questionID, string name, int orderNo) {
            QuestionID = questionID;
            Name = name;
            OrderNo = orderNo;
            ChoiceID = choiceID;            
        }
        public Choice(Func<Choice, bool> bind) {
            bind(this);           
        }        
    }

    public class Choices {
        private QueryList<Choice> choices;
        private int QuestionID;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        public Choices(int questionID) {
            choices = new QueryList<Choice>();
            QuestionID = questionID;
        }
 

        public List<Choice> toList() {
            return choices.toList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemArray"></param>
        /// <returns></returns>
        public bool Add(string[] itemArray) {
            for (int i = 0; i < itemArray.Length; i++) {
                if (!isExist(itemArray[i].ToString())) {
                    choices.Add(new Choice(-1, QuestionID, itemArray[i].ToString(), i + 1));
                }                
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceID"></param>
        /// <param name="questionID"></param>
        /// <param name="name"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool Add(int choiceID, int questionID, string name, int orderNo) {
            choices.Add(new Choice(choiceID, questionID, name, orderNo));
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceID"></param>
        /// <returns></returns>
        public bool Remove(int choiceID) {
            choices.Remove(x => x.ChoiceID == choiceID);
            return true;    
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool isExist(string Name) {
            return choices.Search(x => x.Name == Name).Count > 0 ? true : false;
        }

    }
}


