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
    public class Survey: DataSource
    {
        Query iQuery;
        public Survey(string conn)
        {
            base.Init(conn);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SurveyIDs"></param>
        /// <returns></returns>
        public DataTable GetSurveys(string SurveyIDs)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyID", "cs_survey", FieldType._Number, "")
                    .AddField("Name", "cs_survey", FieldType._Number, "")
                    .AddField("Category", "cs_survey", FieldType._Number, "")
                    .AddField("Description", "cs_survey", FieldType._Number, "")
                    .AddField("IntroductionNote", "cs_survey", FieldType._Number, "")
                    .AddField("ThanksNote", "cs_survey", FieldType._Number, "")
                    .AddField("Status", "cs_survey", FieldType._String, "")
                    .AddField("LastUPD", "cs_survey", FieldType._DateTime, "")
                    .AddWhere(0, "cs_survey", "SurveyID", FieldType._Number, Operator._In, SurveyIDs.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            { 
                throw new Exception("Unable to get survey list. contact system admin", ex.InnerException);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="introNode"></param>
        /// <param name="ThanksNote"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int SaveSurvey(int templateID,
            DateTime startDate, 
            DateTime endDate,
            string name,
            string description,
            string category,
            string introNode,
            string ThanksNote,
            int Status
            )
        {
            int key = 0;
            try
            {
                key = rd.getNextID("SurveyID");
                iQuery = new QueryBuilder(QueryType._Insert)
                     .AddTable("cs_survey")
                     .AddField("SurveyID", "cs_survey", FieldType._Number, "", key.ToString())                     
                     .AddField("SurveyTemplateID", "cs_survey", FieldType._Number, "", templateID .ToString())
                     .AddField("StateDate", "cs_survey", FieldType._DateTime, "", startDate.ToString())
                     .AddField("EndDate", "cs_survey", FieldType._DateTime, "", endDate.ToString())
                    .AddField("Name", "cs_survey", FieldType._String, "", name.ToString())
                     .AddField("Category", "cs_survey", FieldType._String, "", category.ToString())
                .AddField("Description", "cs_survey", FieldType._String, "", description.ToString())
                  .AddField("IntroductionNote", "cs_survey", FieldType._String, "", introNode.ToString())
                 .AddField("ThanksNote", "cs_survey", FieldType._String, "", ThanksNote.ToString())
                 .AddField("Status", "cs_survey", FieldType._String, "", Status.ToString())
                 .AddField("LastUPD", "cs_survey", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                if (rd.ExecuteQuery(iQuery).Result)
                {
                    return key;
                }
                else return 0;
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to survey. contact system admin", ex.InnerException);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="introNode"></param>
        /// <param name="ThanksNote"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool UpdateSurvey(int surveyID, string name,
            string description,
            string category,
            string introNode,
            string ThanksNote,
            DateTime startDate,
            DateTime endDate
            )
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                   .AddField("Name", "cs_survey", FieldType._String, "", name.ToString())
                   .AddField("Category", "cs_survey", FieldType._String, "", category.ToString())
                   .AddField("Description", "cs_survey", FieldType._String, "", description.ToString())
                   .AddField("IntroductionNote", "cs_survey", FieldType._String, "", introNode.ToString())
                   .AddField("ThanksNote", "cs_survey", FieldType._String, "", ThanksNote.ToString())
                   .AddField("StateDate", "cs_survey", FieldType._DateTime, "", startDate.ToString())
                     .AddField("EndDate", "cs_survey", FieldType._DateTime, "", endDate.ToString())                   
                   .AddField("LastUPD", "cs_survey", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                   .AddWhere(0, "cs_survey", "SurveyID", FieldType._Number, surveyID.ToString());                
            }
            catch (Exception e)
            {
                throw new Exception("unable to update survey. contact system admin", e.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyID"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool ChangeEndDate(int surveyID, DateTime endDate) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Update)                 
                     .AddField("EndDate", "cs_survey", FieldType._DateTime, "", endDate.ToString())
                   .AddField("LastUPD", "cs_survey", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                   .AddWhere(0, "cs_survey", "SurveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("unable to update survey. contact system admin", e.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ChangeStatus(int surveyID, int status)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                     .AddField("Status", "cs_survey", FieldType._Number, "", status.ToString())
                   .AddField("LastUPD", "cs_survey", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                   .AddWhere(0, "cs_survey", "SurveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("unable to update survey. contact system admin", e.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyID"></param>
        /// <returns></returns>
        public bool Remove(int surveyID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_survey")
                    .AddWhere(0, "cs_survey", "SurveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove survey template. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

    }
}
