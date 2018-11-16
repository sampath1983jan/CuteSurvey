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
   public class QuestionChoices: DataSource
    {
        Query iQuery;
        public QuestionChoices(string conn)
        {
            base.Init(conn);
        }

        public DataTable GetChoice(int surveyTempleteID,int questionID, int choiceID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                    .AddField("SurveyTemplateID", "cs_question_choices", FieldType._Number, "")
                    .AddField("questionID", "cs_question_choices", FieldType._Number, "")
                    .AddField("choiceID", "cs_question_choices", FieldType._Number, "")
                    .AddField("Name", "cs_question_choices", FieldType._String, "")                    
                    .AddField("OrderNo", "cs_question_choices", FieldType._Number, "")
                    .AddWhere(0, "cs_question_choices", "questionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTempleteID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "choiceID", FieldType._Number, Operator._Equal, choiceID.ToString());
                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get choice list. contact system admin", ex.InnerException);
            }
        }

        public DataTable GetChoices(int surveyTemplateID, int questionID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Select)
                        .AddField("SurveyTemplateID", "cs_question_choices", FieldType._Number, "")
                          .AddField("questionID", "cs_question_choices", FieldType._Number, "")
                    .AddField("choiceID", "cs_question_choices", FieldType._Number, "")
                 .AddField("Name", "cs_question_choices", FieldType._String, "")
                    .AddField("OrderNo", "cs_question_choices", FieldType._Number, "")
                    .AddWhere(0, "cs_question_choices", "questionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());

                return rd.ExecuteQuery(iQuery).GetResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Save(int surveyTemplateID,int questionID, string choice,  int ChoiceNo)
        {
            try
            {
                int key = rd.getNextID("choice");
                iQuery = new QueryBuilder(QueryType._Insert)
                    .AddField("SurveyTemplateID", "cs_question_choices", FieldType._Number, "", surveyTemplateID.ToString())
                      .AddField("questionID", "cs_question_choices", FieldType._Number, "", questionID.ToString())
                    .AddField("choiceID", "cs_question_choices", FieldType._Number, "", key.ToString())
                    .AddField("Name", "cs_question_choices", FieldType._String, "", choice)                  
                    .AddField("OrderNo", "cs_question_choices", FieldType._Number, "", ChoiceNo.ToString())
                    .AddField("LastUPD", "cs_question_choices", FieldType._DateTime, "", DateTime.Now.Date.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Update(int surveyTemplateID,int questionID, int choiceID, string name, int ChoiceNo)
        {

            try
            {
                iQuery = new QueryBuilder(QueryType._Update)
                    .AddField("Name", "cs_question_choices", FieldType._String, "", name)                  
                    .AddField("OrderNo", "cs_question_choices", FieldType._Number, "", ChoiceNo.ToString())
                    .AddField("LastUPD", "cs_question_choices", FieldType._DateTime, "", DateTime.Now.Date.ToString())
                    .AddWhere(0, "cs_question_choices", "questionID", FieldType._Number, Operator._Equal, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "choiceID", FieldType._Number, Operator._Equal, choiceID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "SurveyTemplateID", FieldType._Number, Operator._Equal, surveyTemplateID.ToString());
                return rd.ExecuteQuery(iQuery).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get survey choice list. contact system admin", ex.InnerException);
            }
        }

        public bool Remove(int surveyTemplateID,int questionID, int choiceID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_question_choices")
                    .AddWhere(0, "cs_question_choices", "questionID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "choiceID", FieldType._Number, choiceID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
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
                    .AddField("*", "cs_question_choices")
                    .AddWhere(0, "cs_question_choices", "questionID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove choice list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }
        public bool RemoveAll(int surveyTemplateID)
        {
            try
            {
                iQuery = new QueryBuilder(QueryType._Delete)
                    .AddField("*", "cs_question_choices")
                   // .AddWhere(0, "cs_question_choices", "questionID", FieldType._Number, questionID.ToString(), Condition._And)
                    .AddWhere(0, "cs_question_choices", "SurveyTemplateID", FieldType._Number, surveyTemplateID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("unable to remove choice list. contact system admin", ex.InnerException);
            }
            return rd.ExecuteQuery(iQuery).Result;
        }

    }
}
