using CuteSurvey.SurveyFactory.Component.QuestionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory.Component
{
    public class QuestionFactory
    {
        public static Question Create(IQuestionFactory factory, SurveyQuestionType surveyQuestionType) {
            return factory.Create(surveyQuestionType);
        }
        public static Question CreateDefault(IQuestionFactory factory, SurveyQuestionType surveyQuestionType) {
            return factory.Create(surveyQuestionType);
        }
    }
    public interface IQuestionFactory {
        Question Create(SurveyQuestionType questionType);
        IQuestionFactory CreateDefault(SurveyQuestionType questionType);
    }

    public class QuestionHanlderFactory : IQuestionFactory
    {
        public Question Create(SurveyQuestionType questionType)
        {
     switch  (questionType){
                case SurveyQuestionType._input:
                    return new InputQuestion();
                case SurveyQuestionType._LikelyQuestion:
                    return new LikelyQuestion();
                case SurveyQuestionType._MatricSelection:
                   return new MatricsQuestion();                
                case SurveyQuestionType._Range:
                    return new RangeQuestion();
                case SurveyQuestionType._Ranking:
                    return new RankingQuestion();
                case SurveyQuestionType._singleSelection:
                    return new SingleSelectionQuestion();
                case SurveyQuestionType._MatricsMultiChoice:
                    return new MatricsMultiChoiseQuestion(); 
                default:
                    return new InputQuestion();
                }
        }

        public IQuestionFactory CreateDefault(SurveyQuestionType questionType)
        {
            throw new NotImplementedException();
        }
    }
}
