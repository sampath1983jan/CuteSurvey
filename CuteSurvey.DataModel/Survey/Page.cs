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
    class Page: DataSource
    {
        public Query iQuery;
        public Page(string conn)
        {
            base.Init(conn);
        }


        public DataTable GetPage(int SurveyID, int pageID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyID", "cs_survey_pages", FieldType._Number, "")
                    .AddField("PageID", "cs_survey_pages", FieldType._Number, "")
                    .AddField("PageName", "cs_survey_pages", FieldType._String, "")
                    .AddField("PageDescription", "cs_survey_pages", FieldType._Text, "")
                    .AddField("PageNo", "cs_survey_pages", FieldType._Number, "")

                    .AddWhere(0, "cs_survey_pages", "SurveyID", FieldType._Number, Operator._Equal, SurveyID.ToString(), Condition._And)
                    .AddWhere(0, "cs_survey_pages", "pageID", FieldType._Number, Operator._Equal, pageID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get page list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetPages(int SurveyID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                        .AddField("SurveyID", "cs_survey_pages", FieldType._Number, "")
                    .AddField("PageID", "cs_survey_pages", FieldType._Number, "")
                    .AddField("PageName", "cs_survey_pages", FieldType._String, "")
                    .AddField("PageDescription", "cs_survey_pages", FieldType._Text, "")
                    .AddField("PageNo", "cs_survey_pages", FieldType._Number, "")
                    .AddWhere(0, "cs_survey_pages", "SurveyID", FieldType._Number, Operator._Equal, SurveyID.ToString());

                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get page list. contact system admin", ex.InnerException);
            }
        }

        public bool Save(int SurveyID, string PageName, string PageDescription, int PageNo)
        {
            try
            {
                int key = rd.getNextID("Page");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("SurveyID", "cs_survey_pages", FieldType._Number, "", SurveyID.ToString())
                    .AddField("PageID", "cs_survey_pages", FieldType._Number, "", key.ToString())
                    .AddField("PageName", "cs_survey_pages", FieldType._String, "", PageName)
                    .AddField("PageDescription", "cs_survey_pages", FieldType._Text, "", PageDescription)
                    .AddField("PageNo", "cs_survey_pages", FieldType._Number, "", PageNo.ToString())
                    .AddField("LastUPD", "cs_survey_pages", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey page list. contact system admin", ex.InnerException);
            }
        }

        public bool Update(int SurveyID, int pageID, string PageName, string PageDescription, int PageNo)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                    .AddField("PageName", "cs_survey_pages", FieldType._String, "", PageName)
                    .AddField("PageDescription", "cs_survey_pages", FieldType._Text, "", PageDescription)
                    .AddField("PageNo", "cs_survey_pages", FieldType._Number, "", PageNo.ToString())
                    .AddField("LastUPD", "cs_survey_pages", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                    .AddWhere(0, "cs_survey_pages", "pageID", FieldType._Number, Operator._Equal, pageID.ToString(), Condition._And)
                    .AddWhere(0, "cs_survey_pages", "SurveyID", FieldType._Number, Operator._Equal, SurveyID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey page list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int SurveyID, int pageID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_survey_pages")
                    .AddWhere(0, "cs_survey_pages", "pageID", FieldType._Number, pageID.ToString(), Condition._And)
                    .AddWhere(0, "cs_survey_pages", "SurveyID", FieldType._Number, SurveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove page list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

        public bool RemoveAll(int SurveyID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_survey_pages")
                    .AddWhere(0, "cs_survey_pages", "SurveyID", FieldType._Number, SurveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove page list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
    }
}
