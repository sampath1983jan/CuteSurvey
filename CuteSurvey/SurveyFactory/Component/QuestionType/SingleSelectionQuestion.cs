using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory.Component.QuestionType
{
    public class SingleSelectionQuestion : Question
    {
     
        public override Question Clone()
        {
            //throw new NotImplementedException();
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
