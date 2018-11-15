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
    public class SurveyTemplate : DataSource
    {
        Query iQuery;
        public SurveyTemplate(string conn)
        {
            base.Init(conn);
        }
        
        public DataTable GetSurveyTemplate(string SurveyTemplateIDs) {
         try {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyTemplateID", "cs_surveytemplate", FieldType._Number, "")
                    .AddField("Name", "cs_surveytemplate", FieldType._Number, "")
                    .AddField("Category", "cs_surveytemplate", FieldType._Number, "")
                    .AddField("Description", "cs_surveytemplate", FieldType._Number, "")
                    .AddField("IntroductionNote", "cs_surveytemplate", FieldType._Number, "")
                    .AddField("ThanksNote", "cs_surveytemplate", FieldType._Number, "")
                    .AddField("PagesID", "cs_surveytemplate", FieldType._String, "")
                    .AddField("LastUPD", "cs_surveytemplate", FieldType._DateTime, "")
                    .AddWhere(0, "cs_surveytemplate", "SurveyTemplateID", FieldType._Number,Operator._In, SurveyTemplateIDs.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            } catch (Exception ex)
            {
                throw new Exception("Unable to get survey template list. contact system admin", ex.InnerException);
            }
           
        }

        public int SaveTemplate(string name,
            string description,
            string category,
            string introNode,
            string ThanksNote,
            string pageIDs
            ) {
            int templateid=0;
            try
            {
                   templateid =rd.getNextID("surveyTemplate");
                iQuery = new QueryBuilder(QueryType._Insert)
                     .AddTable("cs_surveytemplate")
                     .AddField("SurveyTemplateID", "cs_surveytemplate", FieldType._Number, "", templateid.ToString())
                    .AddField("Name", "cs_surveytemplate", FieldType._String, "", name.ToString())
                     .AddField("Category", "cs_surveytemplate", FieldType._String, "", category.ToString())
                .AddField("Description", "cs_surveytemplate", FieldType._String, "", description.ToString())
                  .AddField("IntroductionNote", "cs_surveytemplate", FieldType._String, "", introNode.ToString())
                 .AddField("ThanksNote", "cs_surveytemplate", FieldType._String, "", ThanksNote.ToString())
                 .AddField("PagesID", "cs_surveytemplate", FieldType._String, "", pageIDs.ToString())
                 .AddField("LastUPD", "cs_surveytemplate", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                if (rd.ExecuteQuery(iQuery).Result)
                {
                    return templateid;
                }
                else return 0;
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to survey template. contact system admin", ex.InnerException);
            }
           
           
        }

        public bool UpdateTemplate(int templateID,string name,
            string description,
            string category,
            string introNode,
            string ThanksNote)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                   .AddField("Name", "cs_surveytemplate", FieldType._String, "", name.ToString())
                   .AddField("Category", "cs_surveytemplate", FieldType._String, "", category.ToString())
                   .AddField("Description", "cs_surveytemplate", FieldType._String, "", description.ToString())
                   .AddField("IntroductionNote", "cs_surveytemplate", FieldType._String, "", introNode.ToString())
                   .AddField("ThanksNote", "cs_surveytemplate", FieldType._String, "", ThanksNote.ToString())
                   //.AddField("PagesID", "cs_surveytemplate", FieldType._String, "", pageIDs.ToString())
                   .AddField("LastUPD", "cs_surveytemplate", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                   .AddWhere(0, "cs_surveytemplate", "SurveyTemplateID", FieldType._Number, templateID.ToString());
                   ;
            }
            catch (Exception e) {
                throw new Exception("unable to update survey template. contact system admin", e.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
        public bool Remove(int templateID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_surveytemplate")
                    .AddWhere(0, "cs_surveytemplate", "SurveyTemplateID", FieldType._Number, templateID.ToString());
            }
            catch (Exception ex) {
                throw new Exception("unable to remove survey template. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
        public bool updatePages(int templateID, string pageIDs) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Update)                  
                  .AddField("PagesID", "cs_surveytemplate", FieldType._String, "", pageIDs.ToString())
                  .AddField("LastUPD", "cs_surveytemplate", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                  .AddWhere(0, "cs_surveytemplate", "SurveyTemplateID", FieldType._Number, templateID.ToString());
                ;
            }
            catch (Exception ex) {
                throw new Exception("unable to update pages in survey template. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
    }



    }    

