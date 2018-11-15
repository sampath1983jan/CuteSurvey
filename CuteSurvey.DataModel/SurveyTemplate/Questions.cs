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
    public class Questions : DataSource
    {
        Query iQuery;
        public Questions(string conn)
        {
            base.Init(conn);
        }

        public DataTable GetQuestion(int surveyTempleteID, int questionID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyTemplateID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("QuestionID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("QuestionName", "cs_SurveyTemplate_Questions", FieldType._String, "")
                    .AddField("Description", "cs_SurveyTemplate_Questions", FieldType._Text, "")
                    .AddField("QuestionType", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("Note", "cs_SurveyTemplate_Questions", FieldType._Text, "")
                    .AddField("IsRequired", "cs_SurveyTemplate_Questions", FieldType._Question, "")
                    .AddField("MaxLength", "cs_SurveyTemplate_Questions", FieldType._Number, "")

                    .AddField("SelectionChoice", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("enableComment", "cs_SurveyTemplate_Questions", FieldType._Question, "")
                    .AddField("PageNo", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("ValidationMessage", "cs_SurveyTemplate_Questions", FieldType._String, "")

                    .AddWhere(0, "cs_SurveyTemplate_Questions", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTempleteID.ToString(),Condition._And)
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "questionID", FieldType._Number, Operator._Equal, questionID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey template list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetQuestions(int surveyTemplateID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyTemplateID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("QuestionID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("QuestionName", "cs_SurveyTemplate_Questions", FieldType._String, "")
                    .AddField("Description", "cs_SurveyTemplate_Questions", FieldType._Text, "")
                    .AddField("QuestionType", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("Note", "cs_SurveyTemplate_Questions", FieldType._Text, "")
                    .AddField("IsRequired", "cs_SurveyTemplate_Questions", FieldType._Question, "")
                    .AddField("MaxLength", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("SelectionChoice", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("enableComment", "cs_SurveyTemplate_Questions", FieldType._Question, "")
                    .AddField("PageNo", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                    .AddField("ValidationMessage", "cs_SurveyTemplate_Questions", FieldType._String, "")
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());
                    
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey template list. contact system admin", ex.InnerException);
            }
        }

        public int Save(int surveyTemplateID, string questionName,string questionDescription,int questionType,string note,
            bool isRequired,int maxLength, int selectionChoice, bool enableComments,int pageNo,string validationMsg) {
            try
            {
                int key =rd.getNextID("Question");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("SurveyTemplateID", "cs_SurveyTemplate_Questions", FieldType._Number, "", surveyTemplateID.ToString())
                    .AddField("QuestionID", "cs_SurveyTemplate_Questions", FieldType._Number, "", key.ToString())
                    .AddField("QuestionName", "cs_SurveyTemplate_Questions", FieldType._String, "", questionName)
                    .AddField("Description", "cs_SurveyTemplate_Questions", FieldType._Text, "", questionDescription)
                    .AddField("QuestionType", "cs_SurveyTemplate_Questions", FieldType._Number, "", questionType.ToString())
                    .AddField("Note", "cs_SurveyTemplate_Questions", FieldType._Text, "",note)
                    .AddField("IsRequired", "cs_SurveyTemplate_Questions", FieldType._Question, "",isRequired.ToString())
                    .AddField("MaxLength", "cs_SurveyTemplate_Questions", FieldType._Number, "",maxLength.ToString())
                    .AddField("SelectionChoice", "cs_SurveyTemplate_Questions", FieldType._Number, "",selectionChoice.ToString())
                    .AddField("enableComment", "cs_SurveyTemplate_Questions", FieldType._Question, "",enableComments.ToString())
                    .AddField("PageNo", "cs_SurveyTemplate_Questions", FieldType._Number, "",pageNo.ToString())
                    .AddField("ValidationMessage", "cs_SurveyTemplate_Questions", FieldType._String, "",validationMsg)
                    .AddField("LastUPD", "cs_SurveyTemplate_Questions", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                if (rd.ExecuteQuery(iQuery).Result)
                {
                    return key;
                }
                else return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey template list. contact system admin", ex.InnerException);
            }
        }

        public bool Update(int surveyTemplateID, int questionID, string questionName, string questionDescription, string note,
            bool isRequired, int maxLength, int selectionChoice, bool enableComments, int pageNo, string validationMsg)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                      //        .AddField("SurveyTemplateID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                      //      .AddField("QuestionID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
                      .AddField("QuestionName", "cs_SurveyTemplate_Questions", FieldType._String, "", questionName)
                    .AddField("Description", "cs_SurveyTemplate_Questions", FieldType._Text, "", questionDescription)
              //      .AddField("QuestionType", "cs_SurveyTemplate_Questions", FieldType._Number, "", questionType.ToString())
                    .AddField("Note", "cs_SurveyTemplate_Questions", FieldType._Text, "", note)
                    .AddField("IsRequired", "cs_SurveyTemplate_Questions", FieldType._Question, "", isRequired.ToString())
                    .AddField("MaxLength", "cs_SurveyTemplate_Questions", FieldType._Number, "", maxLength.ToString())
                    .AddField("SelectionChoice", "cs_SurveyTemplate_Questions", FieldType._Number, "", selectionChoice.ToString())
                    .AddField("enableComment", "cs_SurveyTemplate_Questions", FieldType._Question, "", enableComments.ToString())
                    .AddField("PageNo", "cs_SurveyTemplate_Questions", FieldType._Number, "", pageNo.ToString())
                    .AddField("ValidationMessage", "cs_SurveyTemplate_Questions", FieldType._String, "", validationMsg)
                    .AddField("LastUPD", "cs_SurveyTemplate_Questions", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "QuestionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey template list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int surveyTemplateID, int questionID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_SurveyTemplate_Questions")
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "questionID", FieldType._Number, questionID.ToString(),Condition._And)
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove survey template. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

        public bool RemoveAll(int surveyTemplateID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_SurveyTemplate_Questions")                   
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove survey template. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
    }
}
