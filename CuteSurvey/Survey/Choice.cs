using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory;
using CuteSurvey.SurveyFactory.Component.QuestionItem;
using CuteSurvey.Utility;

namespace CuteSurvey.Survey.QuestionItem
{
    public class Choice: ChoiceProvider
    {
        public int SurveyID { get; set; }
        public Choice(int surveyID,int questionID)
        {
            SurveyID = surveyID;
            QuestionID = questionID;
        }

        public Choice(int surveyID, int choiceID, int questionID, string name, int orderNo)
        {
            QuestionID = questionID;
            this.SurveyID = surveyID;
            Name = name;
            OrderNo = orderNo;
            ChoiceID = choiceID;
        }
    }

    public class Choices {
        public int SurveyID { get; set; }
        private QueryList<Choice> choices { get; set; }
        private int QuestionID { get; set; }
        public Choices(int surveyID, int questionID) {
            SurveyID = surveyID;
            QuestionID = questionID;
        }

         

        public List<Choice> toList()
        {
            return choices.toList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemArray"></param>
        /// <returns></returns>
        public bool Add(string[] itemArray)
        {
            for (int i = 0; i < itemArray.Length; i++)
            {
                if (!isExist(itemArray[i].ToString()))
                {
                    choices.Add(new Choice(SurveyID, -1, QuestionID, itemArray[i].ToString(), i + 1));
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
        public bool Add(int choiceID, string name, int orderNo)
        {
            choices.Add(new Choice(SurveyID, choiceID, this.QuestionID, name, orderNo));
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
        public bool Remove(int choiceID)
        {
            choices.Remove(x => x.ChoiceID == choiceID);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool isExist(string Name)
        {
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


