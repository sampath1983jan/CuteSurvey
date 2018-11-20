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
    public class SurveyUser : DataSource
    {
        Query iQuery;
        public SurveyUser(string conn)
        {
            base.Init(conn);
        }
        public DataTable GetSurveyUserList(int surveyID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("surveyID", "cs_survey_user", FieldType._Number, "")
                    .AddField("UserID", "cs_survey_user", FieldType._Number, "")
                    .AddField("Status", "cs_survey_user", FieldType._Number, "")
                    .AddWhere(0, "cs_survey_user", "surveyID", FieldType._Number, surveyID.ToString());
                
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey user list. contact system admin", ex.InnerException);
            }
        }
        public void AddUser(int surveyID, int userID, int status) {
            iQuery = new QueryBuilder(QueryType._BulkInsert)
                  .AddField("surveyID", "cs_survey_user", FieldType._Number, "", surveyID.ToString())
                  .AddField("UserID", "cs_survey_user", FieldType._Number, "",userID.ToString())
                  .AddField("Status", "cs_survey_user", FieldType._Number, "",status.ToString());
            
        }
        public bool SaveUser() {
            try
            {
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex) {
                throw ex;
            }            
        }

        public bool SaveUser(int surveyID, int userID, int status) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Insert)
               .AddField("surveyID", "cs_survey_user", FieldType._Number, "", surveyID.ToString())
               .AddField("UserID", "cs_survey_user", FieldType._Number, "", userID.ToString())
               .AddField("Status", "cs_survey_user", FieldType._Number, "", status.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex) {
                throw ex;
            }          
        }
        public bool ChangeStatus(int surveyID, int userID, int status) {
            try
            {
               iQuery = new QueryBuilder(QueryType._Insert)
            // .AddField("surveyID", "cs_survey_user", FieldType._Number, "", surveyID.ToString())
            // .AddField("UserID", "cs_survey_user", FieldType._Number, "", userID.ToString())
               .AddField("Status", "cs_survey_user", FieldType._Number, "", status.ToString())
               .AddWhere(0, "cs_survey_user", "UserID", FieldType._Number, userID.ToString())
               .AddWhere(0, "cs_survey_user", "surveyID", FieldType._Number, surveyID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RemoveUser(int surveyID, int userID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                // .AddField("surveyID", "cs_survey_user", FieldType._Number, "", surveyID.ToString())
                // .AddField("UserID", "cs_survey_user", FieldType._Number, "", userID.ToString())
                .AddField("Status", "cs_survey_user", FieldType._Number, "")
                .AddWhere(0, "cs_survey_user", "UserID", FieldType._Number, userID.ToString())
                .AddWhere(0, "cs_survey_user", "surveyID", FieldType._Number, surveyID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
