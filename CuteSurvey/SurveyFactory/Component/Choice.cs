using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Utility;
namespace CuteSurvey.SurveyFactory.Component.QuestionItem
{
    public abstract class ChoiceProvider {
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public int ChoiceID { get; set; }
        public int QuestionID { get; set; }
        public int SurveyTemplateID { get; set; }
    }

    public class Choice: ChoiceProvider
    {
        
        public Choice(int surveyTemplateID, int choiceID,int questionID, string name, int orderNo) {
            QuestionID = questionID;
            this.SurveyTemplateID = surveyTemplateID;
            Name = name;
            OrderNo = orderNo;
            ChoiceID = choiceID;            
        }
        public Choice(Func<Choice, bool> bind) {
            bind(this);           
        }
        public Choice() {

        }
    }

    public class Choices {
        private int SurveyTemplateID { get; set; }
        private QueryList<Choice> choices { get; set; }
        private int QuestionID { get; set; }        
        /// <summary>
        /// 
        /// </summary>
        public Choices() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        public Choices(int questionID,int surveyTemplateID) {
            SurveyTemplateID = surveyTemplateID;
            QuestionID = questionID;
            choices = new QueryList<Choice>();                        
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
                    choices.Add(new Choice(SurveyTemplateID, -1, QuestionID, itemArray[i].ToString(), i + 1));
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
        public bool Add(int choiceID, string name, int orderNo) {
            choices.Add(new Choice(SurveyTemplateID,choiceID, this.QuestionID, name, orderNo));
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
        public bool Add(Choice c)
        {
            choices.Add(c);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool isExist(int choiceID)
        {
            return choices.Search(x => x.ChoiceID == choiceID).Count > 0 ? true : false;
        }

        public Choice getChoice(int choiceID)
        {
            return this.choices.Search(x => x.ChoiceID == choiceID).FirstOrDefault();
        }

    }
}


