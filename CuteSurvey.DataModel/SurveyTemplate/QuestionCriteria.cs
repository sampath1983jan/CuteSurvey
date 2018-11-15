using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TechSharpy.Data;
using TechSharpy.Data.ABS;
namespace CuteSurvey.Data
{
  public  class QuestionCriteria: DataSource
    {
        Query iQuery;
        public QuestionCriteria(string conn)
        {
            base.Init(conn);
        }


        public DataTable GetCriterias(int surveyTempleteID, int questionID,int CriteriaID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyTemplateID", "cs_question_criterias", FieldType._Number, "")
                    .AddField("CriteriaID", "cs_question_criterias", FieldType._Number, "")
                    .AddField("Name", "cs_question_criterias", FieldType._String, "")
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "")
                    .AddWhere(0, "cs_question_criterias", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTempleteID.ToString(), Condition._And)
                       .AddWhere(0, "cs_question_criterias", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, Operator._Equal, CriteriaID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get choice list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetCriteria(int surveyTemplateID, int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                        .AddField("SurveyTemplateID", "cs_question_criterias", FieldType._Number, "")
                    .AddField("CriteriaID", "cs_question_criterias", FieldType._Number, "")
                 .AddField("Name", "cs_question_criterias", FieldType._String, "")
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "")
                      .AddWhere(0, "cs_question_criterias", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());

                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Save(int surveyTemplateID, int questionID, string criteria, int criteriaNo)
        {
            try
            {
                int key = rd.getNextID("choice");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("SurveyTemplateID", "cs_question_criterias", FieldType._Number, "", surveyTemplateID.ToString())
                    .AddField("QuestionID", "cs_question_criterias", FieldType._Number, "", questionID.ToString())
                    .AddField("CriteriaID", "cs_question_criterias", FieldType._Number, "", key.ToString())
                    .AddField("Name", "cs_question_criterias", FieldType._String, "", criteria)
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "", criteriaNo.ToString())
                    .AddField("LastUPD", "cs_question_criterias", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Update(int surveyTemplateID,int questionID, int CriteriaID, string criteria, int criteriaNo)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                    .AddField("Name", "cs_question_criterias", FieldType._String, "", criteria)
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "", criteriaNo.ToString())
                    .AddField("LastUPD", "cs_question_criterias", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                    .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, Operator._Equal, CriteriaID.ToString(), Condition._And)
                            .AddWhere(0, "cs_question_criterias", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int surveyTemplateID,int questionID, int CriteriaID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_question_criterias")
                            .AddWhere(0, "cs_question_criterias", "questionID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, CriteriaID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove choice list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

        public bool RemoveAll(int surveyTemplateID,int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_question_criterias")
                      .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove choice list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
    }
}
