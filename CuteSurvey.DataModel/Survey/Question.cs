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
    public class Question: DataSource
    {
        Query iQuery;
        public Question(string conn)
        {
            base.Init(conn);
        }
        public DataTable GetQuestion(int surveyID, int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("surveyID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
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

                    .AddWhere(0, "cs_SurveyTemplate_Questions", "surveyID", FieldType._Number, Operator._Equal, surveyID.ToString(), Condition._And)
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "questionID", FieldType._Number, Operator._Equal, questionID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetQuestions(int surveyID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("surveyID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
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
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "surveyID", FieldType._Number, Operator._Equal, surveyID.ToString());

                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey list. contact system admin", ex.InnerException);
            }
        }

        public int Save(int surveyID, string questionName, string questionDescription, int questionType, string note,
            bool isRequired, int maxLength, int selectionChoice, bool enableComments, int pageNo, string validationMsg)
        {
            try
            {
                int key = rd.getNextID("SurveyQuestion");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("surveyID", "cs_SurveyTemplate_Questions", FieldType._Number, "", surveyID.ToString())
                    .AddField("QuestionID", "cs_SurveyTemplate_Questions", FieldType._Number, "", key.ToString())
                    .AddField("QuestionName", "cs_SurveyTemplate_Questions", FieldType._String, "", questionName)
                    .AddField("Description", "cs_SurveyTemplate_Questions", FieldType._Text, "", questionDescription)
                    .AddField("QuestionType", "cs_SurveyTemplate_Questions", FieldType._Number, "", questionType.ToString())
                    .AddField("Note", "cs_SurveyTemplate_Questions", FieldType._Text, "", note)
                    .AddField("IsRequired", "cs_SurveyTemplate_Questions", FieldType._Question, "", isRequired.ToString())
                    .AddField("MaxLength", "cs_SurveyTemplate_Questions", FieldType._Number, "", maxLength.ToString())
                    .AddField("SelectionChoice", "cs_SurveyTemplate_Questions", FieldType._Number, "", selectionChoice.ToString())
                    .AddField("enableComment", "cs_SurveyTemplate_Questions", FieldType._Question, "", enableComments.ToString())
                    .AddField("PageNo", "cs_SurveyTemplate_Questions", FieldType._Number, "", pageNo.ToString())
                    .AddField("ValidationMessage", "cs_SurveyTemplate_Questions", FieldType._String, "", validationMsg)
                    .AddField("LastUPD", "cs_SurveyTemplate_Questions", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                if (rd.ExecuteQuery(iQuery).Result)
                {
                    return key;
                }
                else return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey list. contact system admin", ex.InnerException);
            }
        }

        public bool Update(int surveyID, int questionID, string questionName, string questionDescription, string note,
            bool isRequired, int maxLength, int selectionChoice, bool enableComments, int pageNo, string validationMsg)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                      //        .AddField("surveyID", "cs_SurveyTemplate_Questions", FieldType._Number, "")
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
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "surveyID", FieldType._Number, Operator._Equal, surveyID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int surveyID, int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_SurveyTemplate_Questions")
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "questionID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "surveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove Survey. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

        public bool RemoveAll(int surveyID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_SurveyTemplate_Questions")
                    .AddWhere(0, "cs_SurveyTemplate_Questions", "surveyID", FieldType._Number, surveyID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove Survey. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

    }
}
