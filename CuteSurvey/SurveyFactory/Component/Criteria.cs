﻿using CuteSurvey.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory.Component.QuestionItem
{
 public   class Criteria
    {
        public string Name;
        public int OrderNo;
        public int CriteriaID;
        public int QuestionID;
        public Criteria(int criteriaID, int questionID, string name, int orderNo)
        {
            QuestionID = questionID;
            Name = name;
            OrderNo = orderNo;
            CriteriaID = criteriaID;
        }
        public Criteria(Func<Criteria, bool> bind)
        {
            bind(this);
        }
        public Criteria() {

        }
    }

    public class Criterias {
           private QueryList<Criteria> criterias;
        private int QuestionID;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        public Criterias(int questionID) {
            criterias = new QueryList<Criteria>();
            QuestionID = questionID;
        }
        public List<Criteria> toList() {
            return criterias.toList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemArray"></param>
        /// <returns></returns>
        public bool Add(string[] itemArray) {
            for (int i = 0; i < itemArray.Length; i++) {
                if (!isExist(itemArray[i].ToString())) {
                    criterias.Add(new Criteria(-1, QuestionID, itemArray[i].ToString(), i + 1));
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
        public bool Add(int CriteriaID, string name, int orderNo) {
            criterias.Add(new Criteria(CriteriaID, this.QuestionID, name, orderNo));
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CriteriaID"></param>
        /// <returns></returns>
        public bool Remove(int CriteriaID) {
            criterias.Remove(x => x.CriteriaID == CriteriaID);
            return true;    
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool isExist(string Name) {
            return criterias.Search(x => x.Name == Name).Count > 0 ? true : false;
        }
    }
}