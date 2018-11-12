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

namespace CuteSurvey.SurveyFactory
{
    public abstract class ISurveyTemplate
    {
        int SurveyTemplateID { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }    
        string IntroductionNote { get; set; }
        string ThanksNote { get; set; }
        List<Page> Pages { get; } 
        Questions Questions {  get; }
        public ISurveyActions SurveyHandler { get; set; }
    }
    public interface ISurveyActions {
        bool Save(SurveyTemplate template);
        bool Update(SurveyTemplate template);
        bool Delete(int SurveyTemplateID);
        DataTable Load(int templateID);
    }
    public class SurveyTemplate: ISurveyTemplate
    {
        int surveyTemplateID;
        string name;
        string category;
        string description;
        string introductionNote;
        string thanksNote;
        Questions questions;
        List<Page> pages;
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
        public Questions Questions { get => questions; }
        /// <summary>
        /// 
        /// </summary>
        public List<Page> Pages { get => pages; }
        

        /// <summary>
        /// 
        /// </summary>
        private int CurrentPageNo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyTemplateID"></param>
        public SurveyTemplate(int surveyTemplateID) {
            SurveyTemplateID = surveyTemplateID;
            pages = new List<Page>();
            questions = new Questions(surveyTemplateID);
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
            questions = new Questions(-1);
            pages = new List<Page>();
            AddPage();
        }
        public SurveyTemplate AddPage() {
            CurrentPageNo = CurrentPageNo + 1;
            Pages.Add(new Page(CurrentPageNo, CurrentPageNo));
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
            return SurveyHandler.Save(this);            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Update() {
            return SurveyHandler.Update(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete() {
            return SurveyHandler.Delete(this.surveyTemplateID);
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadTemplate() {
            SurveyHandler.Load(this.surveyTemplateID);
        }
        public ISurveyTemplate AcceptChanges() {
            return this;
        }       
    }

    public class SurveyTemplateImplimentor : ISurveyActions
    {
        public bool Delete(int templateID)
        {
            throw new NotImplementedException();
        }

        public DataTable Load(int templateID)
        {
            Data.SurveyTemplate st = new Data.SurveyTemplate("");           
            throw new NotImplementedException();
        }

        public bool Save(SurveyTemplate template)
        {
            Data.SurveyTemplate st = new Data.SurveyTemplate("SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;");
            template.SurveyTemplateID = st.SaveTemplate(template.Name, template.Description, template.Category, template.IntroductionNote, template.ThanksNote, "");            
            if (template.SurveyTemplateID > 0) {
                return true;
            } else return false;            
        }
        public bool Update(SurveyTemplate template)
        {
            throw new NotImplementedException();
        }//
    }

}



