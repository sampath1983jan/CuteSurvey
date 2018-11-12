using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Survey;
using CuteSurvey.SurveyFactory.Component;

namespace CuteSurvey
{
   public  class UserAnswer : IQuestion
    {
        private int templateID;
        private int questionID;
        private string questionName;
        private string note;
        private string comments;
        private bool isRequired;
       private int maxLength;
        private int pageNo;
        private string validationMessage;
        private SelectionChoice selectionChoice;
        private bool enableComments;
        private string answer;

        public int TemplateID { get => templateID; set => templateID = value; }
        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionName { get => questionName; set=> questionName = value; }
        public string Note { get => note; set => note = value; }
        public string Comments { get => comments; set => comments = value; }
        public bool IsRequired { get => isRequired; set => isRequired=value; }
        public int MaxLength { get => maxLength; set => maxLength=value; }
        public int PageNo { get => pageNo; set => pageNo=value; }
        public string ValidationMessage { get => validationMessage; set => validationMessage=value; }
        public SelectionChoice SelectionChoice { get => selectionChoice; set=>selectionChoice=value; }
        public bool EnableComment { get => enableComments; set => enableComments=value; }
        public string Answer { get => answer; set => answer=value; }

        public Question Default()
        {
            throw new NotImplementedException();
        }
    }
}
