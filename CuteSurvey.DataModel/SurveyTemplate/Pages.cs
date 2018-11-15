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
    public class Pages : DataSource
    {
        Query iQuery;
        public Pages(string conn)
        {
            base.Init(conn);
        }

        public DataTable GetPage(int surveyTempleteID, int pageID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyTemplateID", "cs_surveytemplate_pages", FieldType._Number, "")
                    .AddField("PageID", "cs_surveytemplate_pages", FieldType._Number, "")
                    .AddField("PageName", "cs_surveytemplate_pages", FieldType._String, "")
                    .AddField("PageDescription", "cs_surveytemplate_pages", FieldType._Text, "")
                    .AddField("PageNo", "cs_surveytemplate_pages", FieldType._Number, "")                    

                    .AddWhere(0, "cs_surveytemplate_pages", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTempleteID.ToString(), Condition._And)
                    .AddWhere(0, "cs_surveytemplate_pages", "pageID", FieldType._Number, Operator._Equal, pageID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get page list. contact system admin", ex.InnerException);
            }
        }
        
        public DataTable GetPages(int surveyTemplateID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                        .AddField("SurveyTemplateID", "cs_surveytemplate_pages", FieldType._Number, "")
                    .AddField("PageID", "cs_surveytemplate_pages", FieldType._Number, "")
                    .AddField("PageName", "cs_surveytemplate_pages", FieldType._String, "")
                    .AddField("PageDescription", "cs_surveytemplate_pages", FieldType._Text, "")
                    .AddField("PageNo", "cs_surveytemplate_pages", FieldType._Number, "")
                    .AddWhere(0, "cs_surveytemplate_pages", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());

                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get page list. contact system admin", ex.InnerException);
            }
        }

        public bool Save(int surveyTemplateID, string PageName, string PageDescription, int PageNo)
        {
            try
            {
                int key = rd.getNextID("Page");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("SurveyTemplateID", "cs_surveytemplate_pages", FieldType._Number, "", surveyTemplateID.ToString())
                    .AddField("PageID", "cs_surveytemplate_pages", FieldType._Number, "", key.ToString())
                    .AddField("PageName", "cs_surveytemplate_pages", FieldType._String, "", PageName)
                    .AddField("PageDescription", "cs_surveytemplate_pages", FieldType._Text, "", PageDescription)
                    .AddField("PageNo", "cs_surveytemplate_pages", FieldType._Number, "", PageNo.ToString())                  
                    .AddField("LastUPD", "cs_surveytemplate_pages", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey page list. contact system admin", ex.InnerException);
            }
        }

        public bool Update(int surveyTemplateID,int pageID, string PageName, string PageDescription, int PageNo)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)                      
                    .AddField("PageName", "cs_surveytemplate_pages", FieldType._String, "", PageName)
                    .AddField("PageDescription", "cs_surveytemplate_pages", FieldType._Text, "", PageDescription)
                    .AddField("PageNo", "cs_surveytemplate_pages", FieldType._Number, "", PageNo.ToString())                
                    .AddField("LastUPD", "cs_surveytemplate_pages", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                    .AddWhere(0, "cs_surveytemplate_pages", "pageID", FieldType._Number, Operator._Equal, pageID.ToString(), Condition._And)
                    .AddWhere(0, "cs_surveytemplate_pages", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey page list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int surveyTemplateID, int pageID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_surveytemplate_pages")
                    .AddWhere(0, "cs_surveytemplate_pages", "pageID", FieldType._Number, pageID.ToString(), Condition._And)
                    .AddWhere(0, "cs_surveytemplate_pages", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove page list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

        public bool RemoveAll(int surveyTemplateID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_surveytemplate_pages")
                    .AddWhere(0, "cs_surveytemplate_pages", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove page list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

    }
}
