﻿using CuteSurvey.SurveyFactory;
using CuteSurvey.SurveyFactory.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Utility;
namespace CuteSurvey.Survey
{
    public enum SurveyStatus
    {
        _notstarted = 0,
        _progress = 1,
        _completed = 2
    }
    public abstract class ISurvey{
        int SurveyID { get; set; }
        ISurveyTemplate Template { get; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        SurveyStatus Status { get; set; }
        int SurveyTemplateID { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        string IntroductionNote { get; set; }
        string ThanksNote { get; set; }
        Pages Pages { get; }
       Questions Questions { get; }
        public ISurveyHandler SurveyHandler;

    }
    public interface ISurveyHandler {
        bool ChangeStatus(int surveyID, int status);
        bool ChangeEndDate(int surveyID, DateTime endDate);
        int Save(Survey survey);
        bool Update(Survey survey);
        bool Delete(int surveyID);
        DataTable Load(string surveyID);
        DataTable LoadPage(int SurveyID);        
    }

    [Serializable]
    public class Survey:ISurvey 
    {
        private int surveyID;
        private SurveyTemplate template;
        private DateTime startDate;
        private DateTime endDate;
        private SurveyStatus status;

        private int surveyTemplateID;
        private string name;
        private string category;
        private string description;
        private string introNote;
        private string thankNote;
        private Pages pages;
        private Questions questions;

        public int SurveyID { get => surveyID; set => surveyID=value; }
        public SurveyTemplate Template { get => template; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public SurveyStatus Status { get => status; set => status=value; }

        public int SurveyTemplateID { get => surveyTemplateID; set => surveyTemplateID=value; }
        public string Name { get => name; set => name=value; }
        public string Category { get => category; set => category=value; }
        public string Description { get => description; set => description=value; }
        public string IntroductionNote { get => introNote; set => introNote=value; }
        public string ThanksNote { get => thankNote; set => thankNote=value; }

        public Pages Pages => pages;
        public Questions Questions => questions;

        public Survey()
        {
            pages = new Pages();
            questions = new Questions(-1);
        }
        
        public Survey(int templateID, DateTime startDate, DateTime endDate,
            SurveyFactory.ISurveyActions surveyTemplateImplimentor, SurveyFactory.Component.IQuestionsHandler questionsImplimentor, IPage pageImplimentor) {
            Status = SurveyStatus._notstarted;
            template = new SurveyTemplate(templateID);
            template.SurveyTemplateHandler = surveyTemplateImplimentor;
            template.Questions.questionHandler = questionsImplimentor;
            template.Pages.PageHandler = pageImplimentor;
            StartDate = startDate;
            EndDate = endDate;
            pages = new Pages();
            questions = new Questions(templateID);
        }

        public Survey(int surveyID) {
            this.SurveyID = surveyID;
            DataTable dt = new DataTable();
            pages = new Pages(this.surveyID);
           dt= this.SurveyHandler.Load(this.SurveyID.ToString());
          var survey=  dt.toList<Survey>(new DataFieldMappings()
                .Add("SurveyID", "SurveyID")
                .Add("SurveyTemplate", "SurveyTemplateID")
                .Add("StateDate", "StartDate")
                .Add("EndDate", "EndDate")
                .Add("Status", "Status")
                .Add("Name", "Name")
                .Add("Description", "Description")
                .Add("Category", "Category")
                .Add("IntroductionNote", "IntroductionNote")
                .Add("ThankNote", "ThanksNote")                
                , null).FirstOrDefault();
            this.SurveyTemplateID = survey.SurveyTemplateID;
            this.StartDate = survey.StartDate;
            this.EndDate = survey.EndDate;
            this.Status = survey.Status;
            this.Name = survey.Name;
            this.Description = survey.Description;
            this.Category = survey.Category;
            this.IntroductionNote = survey.IntroductionNote;
            this.ThanksNote = survey.ThanksNote;
            this.questions.Load();
            Pages.Load();
        }

        public bool Save() {
            if (this.surveyID > 0) {
            return   SurveyHandler.Update(this);
            }
            else
            {
             this.surveyID= SurveyHandler.Save(this);
                if (this.surveyID > 0)
                {
                    this.questions.Save();
                    this.pages.Save();
                    return true;
                }
                else return false;
            }                      
        }
        
        public bool AddQuestion(Question question) {
         var   newQuestion = this.questions.NewQuestion(this.surveyID, question.QuestionType, this.pages.GetLastPage().PageID);
            CuteSurvey.Utility.Common.Combine<Question>(ref newQuestion, question);
            this.questions.Save(newQuestion);           
            return true;
        }
        public bool AddChoice() {
            return true;
        }

        public bool AddCriteria() {
            return true;
        }

        public bool Remove() {
            if (SurveyHandler.Delete(this.SurveyID))
            {
                this.pages.RemoveAll();
                this.questions.RemoveAll();
                return true;
            }
            else return false;            
        }

       
    }
    
}
