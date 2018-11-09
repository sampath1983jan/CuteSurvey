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
        public string Answer;

        public int TemplateIID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int QuestionID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QuestionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Note { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Comments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsRequired { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PageNo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ValidationMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SelectionChoice SelectionChoice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableComment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Question Default()
        {
            throw new NotImplementedException();
        }
    }
}
