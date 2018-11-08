using CuteSurvey.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Survey.QuestionType;
using System.Dynamic;
using System.ComponentModel;

namespace CuteSurvey.SurveyFactory
{
    public interface ISurveyTemplate {
        int SurveyTemplateID { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }    
        string IntroductionNote { get; set; }
        string ThanksNote { get; set; }
        Questions Questions {  get; }
    }

    public interface ISurveyActions {
        bool Save();
        bool Update();
        bool Delete();
    }

    public class SurveyTemplate: ISurveyTemplate,ISurveyActions
    {
        int surveyTemplateID;
        string name;
        string category;
        string description;
        string introductionNote;
        string thanksNote;
        Questions questions;
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
        /// <param name="surveyTemplateID"></param>
        public SurveyTemplate(int surveyTemplateID) {
            SurveyTemplateID = surveyTemplateID;
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
            ThanksNote = thanksNote;
            questions = new Questions(-1);
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadTemplate() {

        }
        public ISurveyTemplate AcceptChanges() {
            return this;
        }       
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public bool Save()
        {
            throw new NotImplementedException();
        }
        public bool Update()
        {
            throw new NotImplementedException();
        }
        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }   
}



