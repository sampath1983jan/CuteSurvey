using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey;
using CuteSurvey.SurveyFactory.Component.QuestionItem;
using CuteSurvey.Utility;

namespace CuteSurvey.Survey.QuestionItem
{
    public class Criteria: CriteriaProvider
    {
        public int SurveyID { get; set; }
        public Criteria(int surveyID,int questionID) {
            SurveyID = surveyID;
            QuestionID= questionID;
        }

        public Criteria()
        {

        }
        public Criteria(int surveyID, int criteriaID, int questionID, string name, int orderNo)
        {
            SurveyID = surveyID;
            QuestionID = questionID;
            Name = name;
            OrderNo = orderNo;
            CriteriaID = criteriaID;
        }
    }



    public class Criterias  {
        public int SurveyID { get; set; }
        private QueryList<Criteria> criterias { get; set; }
        private int QuestionID { get; set; }

        public Criterias(int surveyID, int questionID)  {
            this.SurveyID = surveyID;
            QuestionID = questionID;
            criterias = new QueryList<Criteria>();
        }
        public Criterias()
        {
            this.SurveyID = -1;
            this.QuestionID = -1;
        }

        public List<Criteria> toList()
        {
            return criterias.toList();
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
                    criterias.Add(new Criteria(this.SurveyID, -1, QuestionID, itemArray[i].ToString(), i + 1));
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CriteriaID"></param>
        /// <param name="questionID"></param>
        /// <param name="name"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool Add(int CriteriaID, string name, int orderNo)
        {
            criterias.Add(new Criteria(this.SurveyID, CriteriaID, this.QuestionID, name, orderNo));
            return true;
        }
        internal bool Add(Criteria c)
        {
            criterias.Add(c);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CriteriaID"></param>
        /// <returns></returns>
        public bool Remove(int CriteriaID)
        {
            criterias.Remove(x => x.CriteriaID == CriteriaID);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool isExist(string Name)
        {
            return criterias.Search(x => x.Name == Name).Count > 0 ? true : false;
        }

        public bool isExist(int criteriaID)
        {
            return criterias.Search(x => x.CriteriaID == criteriaID).Count > 0 ? true : false;
        }

        public Criteria getCriteria(int criteriaID)
        {
            return criterias.Search(x => x.CriteriaID == criteriaID).FirstOrDefault();
        }

    }
}
