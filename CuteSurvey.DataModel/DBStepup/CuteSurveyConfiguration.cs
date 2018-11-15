using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSharpy.Data;

namespace CuteSurvey.Data.DBStepup
{
    internal class CuteSurveyConfiguration:DataSource
    {
        public CuteSurveyConfiguration(string conn)
        {
            base.Init(conn);
        }        

        private void setSurveyTemplate() {
            var tq = new TQueryBuilder(TQueryType._Create);
            tq.TableName("cs_SurveyTemplate");
            tq.AddField("SurveyTemplateID",true,true,FieldType._Number,false);
            tq.AddField("Name", false, false, FieldType._String, false);
            tq.AddField("Category", false, false, FieldType._String, false);
            tq.AddField("Description", false, false, FieldType._Text, false);
            tq.AddField("IntroductionNote", false, false, FieldType._Text, false);
            tq.AddField("ThanksNote", false, false, FieldType._Text, false);
            tq.AddField("PagesID", false, false, FieldType._String, false);
            tq.AddField("LastUPD", false, false, FieldType._DateTime, false);
            rd.ExecuteTQuery(tq);
        }

        private void setTemplateQuestion() {
            var tq = new TQueryBuilder(TQueryType._Create);
            tq.TableName("cs_SurveyTemplate_Questions");
            tq.AddField("SurveyTemplateID", true, true, FieldType._Number, false);
            tq.AddField("QuestionID", true, true, FieldType._Number, false);
            tq.AddField("QuestionName", false, false, FieldType._String, false);
            tq.AddField("Description", false, false, FieldType._Text, false);
            tq.AddField("QuestionType", false, false, FieldType._Number, false);
            tq.AddField("Note", false, false, FieldType._Text, false);
            tq.AddField("IsRequired", false, false, FieldType._Question, false);
            tq.AddField("MaxLength", false, false, FieldType._Number, false);
            tq.AddField("ValidationMessage", false, false, FieldType._Text, false);
            tq.AddField("SelectionChoice", false, false, FieldType._String, false);
            tq.AddField("PageNo", false, false, FieldType._Number, false);
            tq.AddField("EnableComment", false, false, FieldType._Question, false);
            tq.AddField("LastUPD", false, false, FieldType._DateTime, false);
            rd.ExecuteTQuery(tq);
        }

        private void setQuestionChoice() {

        }
    }
}
