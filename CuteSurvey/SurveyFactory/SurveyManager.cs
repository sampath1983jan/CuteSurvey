using CuteSurvey.SurveyFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey
{
  public class SurveyBuilder
    {
        public static bool CreateTemplate(string name, string category, string description, string introNode, string thankNote) {
            CuteSurvey.SurveyFactory.SurveyTemplate st = new SurveyFactory.SurveyTemplate(name,category,description,introNode,thankNote);
            st.SurveyHandler = new Implimentor.SurveyTemplateImplimentor();
            return st.Save();
        }        
    }
}
