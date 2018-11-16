using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TechSharpy.Data;
using TechSharpy.Data.ABS;


namespace CuteSurvey.Data.Survey
{
   public class Critieria:DataSource
    {
        public Query iQuery;
        public Critieria(string conn)
        {
            base.Init(conn);
        }


        public DataTable GetCriterias(int surveyID, int questionID, int CriteriaID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyID", "cs_question_criterias", FieldType._Number, "")
                    .AddField("CriteriaID", "cs_question_criterias", FieldType._Number, "")
                    .AddField("Name", "cs_question_criterias", FieldType._String, "")
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "")
                    .AddWhere(0, "cs_question_criterias", "SurveyID", FieldType._Number, Operator._Equal, surveyID.ToString(), Condition._And)
                       .AddWhere(0, "cs_question_criterias", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, Operator._Equal, CriteriaID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get choice list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetCriteria(int surveyID, int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                        .AddField("SurveyID", "cs_question_criterias", FieldType._Number, "")
                    .AddField("CriteriaID", "cs_question_criterias", FieldType._Number, "")
                 .AddField("Name", "cs_question_criterias", FieldType._String, "")
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "")
                      .AddWhere(0, "cs_question_criterias", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyID", FieldType._Number, Operator._Equal, surveyID.ToString());

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
                int key = rd.getNextID("Surveychoice");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("SurveyID", "cs_question_criterias", FieldType._Number, "", surveyTemplateID.ToString())
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

        public bool Update(int surveyID, int questionID, int CriteriaID, string criteria, int criteriaNo)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                    .AddField("Name", "cs_question_criterias", FieldType._String, "", criteria)
                    .AddField("OrderNo", "cs_question_criterias", FieldType._Number, "", criteriaNo.ToString())
                    .AddField("LastUPD", "cs_question_criterias", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                    .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, Operator._Equal, CriteriaID.ToString(), Condition._And)
                            .AddWhere(0, "cs_question_criterias", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyID", FieldType._Number, Operator._Equal, surveyID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int surveyID, int questionID, int CriteriaID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_question_criterias")
                            .AddWhere(0, "cs_question_criterias", "questionID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, CriteriaID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove choice list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

        public bool RemoveAll(int surveyID, int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_question_criterias")
                      .AddWhere(0, "cs_question_criterias", "CriteriaID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_criterias", "SurveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove choice list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
    }
}
