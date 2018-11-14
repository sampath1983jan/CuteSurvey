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
        public static Question Create(IQuestionFactory factory,int surveyTemplateID, SurveyQuestionType surveyQuestionType) {
            return factory.Create(surveyTemplateID, surveyQuestionType);
        }
        public static Question CreateDefault(IQuestionFactory factory, int surveyTemplateID, SurveyQuestionType surveyQuestionType) {
            return factory.Create(surveyTemplateID, surveyQuestionType);
        }
    }
    public interface IQuestionFactory {
        Question Create(int surveyTemplateID,SurveyQuestionType questionType);
        IQuestionFactory CreateDefault(int surveyTemplateID,SurveyQuestionType questionType);
    }

    public class QuestionHanlderFactory : IQuestionFactory
    {
        public Question Create(int surveyTemplateID, SurveyQuestionType questionType)
        {
     switch  (questionType){
                case SurveyQuestionType._input:
                    return new InputQuestion(surveyTemplateID);
                case SurveyQuestionType._LikelyQuestion:
                    return new LikelyQuestion(surveyTemplateID);
                case SurveyQuestionType._MatricSelection:
                   return new MatricsQuestion(surveyTemplateID);                
                case SurveyQuestionType._Range:
                    return new RangeQuestion(surveyTemplateID);
                case SurveyQuestionType._Ranking:
                    return new RankingQuestion(surveyTemplateID);
                case SurveyQuestionType._singleSelection:
                    return new SingleSelectionQuestion(surveyTemplateID);
                case SurveyQuestionType._MatricsMultiChoice:
                    return new MatricsMultiChoiseQuestion(surveyTemplateID); 
                default:
                    return new InputQuestion(surveyTemplateID);
                }
        }

        public IQuestionFactory CreateDefault(int surveyTemplateID,SurveyQuestionType questionType)
        {
            throw new NotImplementedException();
        }
    }
}
