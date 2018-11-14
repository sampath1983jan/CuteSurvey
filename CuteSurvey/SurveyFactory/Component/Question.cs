
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory.Component.QuestionItem;

namespace CuteSurvey.SurveyFactory.Component
{
    public enum SelectionChoice
    {
        _none = 0,
        _single = 1,
        _multiple = 2
    }

    public enum SurveyQuestionType {
        _input=0,
        _singleSelection=1,        
        _MatricSelection=2, //single or multiple        
        _LikelyQuestion=3,
        _Range=4,
        _MatricsMultiChoice=5, 
        _Ranking=6
    }

    public interface IQuestionAction {
        bool Save();
        bool Update();
        bool Delete();
        bool Validation();
    }
    public interface IQuestion {
        int TemplateID { get; set; }
        int QuestionID { get; set; }
        string QuestionName { get; set; }
        string Note { get; set; }        
        string Comments { get; set; }      
        bool IsRequired { get; set; }
        int MaxLength { get; set; }
        int PageNo { get; set; }
        string ValidationMessage { get; set; }
        
        SelectionChoice SelectionChoice { get; set; }
        bool EnableComment { get; set; }
        Question Default();
    }

    public abstract class QuestionPrototype

    {
        public abstract QuestionPrototype Clone();
    }


    public abstract class Question : IQuestion
    {
        private int templateID;
        private int questionID;
        private string questionName;
        private string note;
        private string comments;
        SelectionChoice selectionChoice;
        private bool isRequired;
        private int maxLength;
        private string validationMessage;
        private int pageNo;
        private bool enableComment;
        public SurveyQuestionType QuestionType;
        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionName { get => questionName; set => questionName=value; }
        public string Note { get => note; set => note=value; }
        public string Comments { get => comments; set => comments=value; }
        public int TemplateID { get => templateID; set => templateID=value; }        
        public bool IsRequired { set => isRequired = value; get => isRequired; }
        public int MaxLength { set => maxLength = value; get => maxLength; }
        public string ValidationMessage { set => validationMessage = value; get => validationMessage; }
        public SelectionChoice SelectionChoice { set => selectionChoice=value; get =>selectionChoice; }
        public int PageNo { get => pageNo; set => pageNo=value; }
        public bool EnableComment { get => enableComment; set => enableComment=value; }

        public abstract Question Clone();
        public abstract Question Default();
        public Choices Choices;
        public Criterias Criterias;

        public  bool Save()
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
        public bool Validation()
        {
            throw new NotImplementedException();
        }
        public  Question DefaultOrFirst()
        {
            QuestionID = -1;
            QuestionName = "";
            Note = "";
            Comments = "";            
            IsRequired = true;
            MaxLength = 1000;
            ValidationMessage = "";
            selectionChoice = SelectionChoice._none;
            Choices = new Choices(QuestionID,templateID);
            Criterias = new Criterias(templateID,questionID);
            pageNo = 1;
            return this;
        }
        public Question(int surveyTemplateID)
        {
            this.TemplateID = surveyTemplateID;
        }


        public Question UpdateKey() {
            foreach (Choice i in Choices.toList()) {
                i.QuestionID = QuestionID;
            }
            return this;
        }        
    }
}
