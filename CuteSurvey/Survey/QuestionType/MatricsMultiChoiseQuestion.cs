using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey.QuestionType
{

    public class MatricsMultiChoiseQuestion : Question
    {
        public override Question Clone()
        {
            //throw new NotImplementedException();
            return this.MemberwiseClone() as Question;
        }
        public override Question Default()
        {
            base.DefaultOrFirst();
            QuestionType = SurveyQuestionType._MatricsMultiChoice;
            return this;
        }

        //    private int templateID;
        //    private int questionID;
        //    private string questionName;
        //    private string note;
        //    private string comments;

        //    //public SurveyQuestionType QuestionType;
        //    public int QuestionID { get => questionID; set => questionID = value; }
        //    public string QuestionName { get => questionName; set => questionName = value; }
        //    public string Note { get => note; set => note = value; }
        //    public string Comments { get => comments; set => comments = value; }
        //    public int TemplateIID { get => templateID; set => templateID = value; }
        //    private bool isRequired;
        //    private int maxLength;
        //    private string validationMessage;
        //    public bool IsRequired { set => isRequired = value; get => isRequired; }
        //    public int MaxLength { set => maxLength = value; get => maxLength; }
        //    public string ValidationMessage { set => validationMessage = value; get => validationMessage; }


        //    public bool Save()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool Update()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool Delete()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool Validation()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
