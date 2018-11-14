using System;
using System.Collections.Generic;
using CuteSurvey.Survey;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory.Component.QuestionType;
using System.Dynamic;
using System.ComponentModel;
using CuteSurvey.SurveyFactory.Component;
using System.Data;
using CuteSurvey.Utility;
using CuteSurvey.SurveyFactory;

namespace CuteSurvey.Implimentor
{
    public class SurveyTemplateImplimentor : SurveyFactory.ISurveyActions
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        public bool Delete(int templateID)
        {
            Data.SurveyTemplate st = new Data.SurveyTemplate(conn);
            return st.Remove(templateID);
        }
        public DataTable Load(int templateID)
        {
            DataTable dt = new DataTable();
            Data.SurveyTemplate st = new Data.SurveyTemplate(conn);
            dt = st.GetSurveyTemplate(templateID.ToString());
            return dt;
        }
        public bool Save(SurveyTemplate template)
        {
            Data.SurveyTemplate st = new Data.SurveyTemplate(conn);
            template.SurveyTemplateID = st.SaveTemplate(template.Name, template.Description, template.Category, template.IntroductionNote, template.ThanksNote, "");
            if (template.SurveyTemplateID > 0)
            {
                return true;
            }
            else return false;
        }
        public bool Update(SurveyTemplate template)
        {
            Data.SurveyTemplate st = new Data.SurveyTemplate(conn);
            return st.UpdateTemplate(template.SurveyTemplateID, template.Name, template.Description, template.Category, template.IntroductionNote, template.ThanksNote);
        }
    }
}
