using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory.Component.QuestionType
{
    public class SingleSelectionQuestion : Question
    {
        public SingleSelectionQuestion(int surveyTemplateID) : base(surveyTemplateID)
        {
            
        }
        
        public override Question Clone()
       {            
            return this.MemberwiseClone() as Question;
        }
        public override Question Default()
        {
            base.DefaultOrFirst();
            QuestionType = SurveyQuestionType._singleSelection;
            return this;
        }
    }
}
