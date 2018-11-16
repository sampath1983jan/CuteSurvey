using CuteSurvey.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory.Component.QuestionType;
using System.Dynamic;
using System.ComponentModel;
using CuteSurvey.SurveyFactory.Component;
using System.Data;
using CuteSurvey.Utility;
using CuteSurvey.Implimentor;

namespace CuteSurvey.SurveyFactory
{
    public interface ISurveyTemplateMembers {
        int SurveyTemplateID { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        string IntroductionNote { get; set; }
        string ThanksNote { get; set; }
       Component.Pages Pages { get; }
        CuteSurvey.SurveyFactory.Component.Questions Questions { get; }
    }

    public abstract class ISurveyTemplate
    {        
        public ISurveyActions SurveyTemplateHandler { get; set; }
    }
    public interface ISurveyActions {
        bool Save(SurveyTemplate template);
        bool Update(SurveyTemplate template);
        bool Delete(int SurveyTemplateID);
        DataTable Load(int templateID);        
    }
    public class SurveyTemplate: ISurveyTemplate, ISurveyTemplateMembers
    {
        private int surveyTemplateID;
        private string name;
        private string category;
        private string description;
        private string introductionNote;
        private string thanksNote;
        private CuteSurvey.SurveyFactory.Component.Questions questions;
        private Component.Pages pages;
        /// <summary>
        /// 
        /// </summary>
        public int SurveyTemplateID { get => surveyTemplateID; set => surveyTemplateID = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Category { get => category; set => category = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// 
        /// </summary>
        public string IntroductionNote { get => introductionNote; set => introductionNote = value; }
        /// <summary>
        /// 
        /// </summary>
        public string ThanksNote { get => thanksNote; set => thanksNote = value; }
        /// <summary>
        /// 
        /// </summary>
        public CuteSurvey.SurveyFactory.Component.Questions Questions { get => questions; }
        /// <summary>
        /// 
        /// </summary>
        public Component.Pages Pages { get => pages; }

        


        /// <summary>
        /// 
        /// </summary>
        private int CurrentPageNo;
        public SurveyTemplate() {
            pages = new Component.Pages(-1);
            questions = new CuteSurvey.SurveyFactory.Component.Questions(-1);
            questions.questionHandler = new CuteSurvey.Implimentor.QuestionImplimentor();
            pages.PageHandler = new PageImplimentor();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyTemplateID"></param>
        public SurveyTemplate(int surveyTemplateID) {
            SurveyTemplateID = surveyTemplateID;
            pages = new Component.Pages(surveyTemplateID);
            pages.PageHandler = new PageImplimentor();
            questions = new CuteSurvey.SurveyFactory.Component.Questions(surveyTemplateID);
            questions.questionHandler = new QuestionImplimentor();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="introNode"></param>
        /// <param name="thankNote"></param>
        public SurveyTemplate(string name, string category, string description, string introNode, string thankNote) {
            Name = name;
            Category = category;
            Description = description;
            IntroductionNote = introNode;
            ThanksNote = thankNote;
            questions = new CuteSurvey.SurveyFactory.Component.Questions(-1);
            questions.questionHandler = new QuestionImplimentor();
            pages = new Component.Pages(-1);
            pages.PageHandler = new PageImplimentor();
            AddPage();
        }
        public SurveyTemplate AddPage() {           
            return this;
        }
        public bool InsertPage(int pageIndex,int PageNo) {            
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save() {
            return SurveyTemplateHandler.Save(this);            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Update() {
            return SurveyTemplateHandler.Update(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete() {
            return SurveyTemplateHandler.Delete(this.surveyTemplateID);
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadTemplate() {
            DataTable dt = new DataTable();
         dt=SurveyTemplateHandler.Load(this.surveyTemplateID);
           SurveyTemplate st;
          st= dt.toList<SurveyTemplate>(new DataFieldMappings()
               .Add("Name", "Name")
               .Add("Category", "Category")               
               .Add("Description", "Description")
               .Add("IntroductionNote", "IntroductionNote")
               .Add("ThanksNote", "ThanksNote")
               .Add("Category", "Category"), null).FirstOrDefault();
            this.name = st.Name;
            this.description = st.Description;
            this.category = st.Category;
            this.thanksNote = st.ThanksNote;
            this.introductionNote = st.IntroductionNote;

            this.questions.Load();

            this.Pages.Load();
        
        }
        public ISurveyTemplate AcceptChanges() {
            return this;
        }       
    }

    


   

    
}



