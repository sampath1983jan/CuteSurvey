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
   public class UserAnswer : DataSource
    {

        Query iQuery;
        public UserAnswer(string conn)
        {
            base.Init(conn);
        }

        public DataTable GetSurveyQuestionAnswer(int surveyID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("surveyID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("QuestionID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("UserID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("ChoiceID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("CriteriaID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("Answer", "cs_survey_user_answer", FieldType._Text, "")
                    .AddField("Comments", "cs_survey_user_answer", FieldType._Text, "")
                    .AddWhere(0, "cs_survey_user_answer", "surveyID", FieldType._Number, Operator._Equal, surveyID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetSurveyQuestionAnswer(int surveyID, int UserID) {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("surveyID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("QuestionID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("UserID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("ChoiceID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("CriteriaID", "cs_survey_user_answer", FieldType._Number, "")
                    .AddField("Answer", "cs_survey_user_answer", FieldType._Text, "")
                    .AddField("Comments", "cs_survey_user_answer", FieldType._Text, "")                                       
                    .AddWhere(0, "cs_survey_user_answer", "surveyID", FieldType._Number, Operator._Equal, surveyID.ToString(), Condition._And)
                    .AddWhere(0, "cs_survey_user_answer", "UserID", FieldType._Number, Operator._Equal, UserID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Survey list. contact system admin", ex.InnerException);
            }
        }


    }
}
