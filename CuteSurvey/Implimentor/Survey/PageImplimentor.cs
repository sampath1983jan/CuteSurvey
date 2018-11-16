using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.SurveyFactory.Component;

namespace CuteSurvey.Implimentor.Survey
{
    public class PageImplimentor : SurveyFactory.Component.IPage
    {
        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        Data.Survey.Page pg;
        public PageImplimentor() {
            pg = new Data.Survey.Page(conn);
        }
        public DataTable Load(int surveyID)
        {
            return pg.GetPages(surveyID);
        }

        public bool Remove(int pageID, int surveyID)
        {
            return pg.Remove(surveyID, pageID);            
        }

        public bool RemoveAll(int suveyID)
        {
            return pg.RemoveAll(suveyID);
        }
        public bool Save(Page page)
        {
            return pg.Save(page.SurveyTemplateID, page.PageTitle, page.Description, page.PageNo);
        }

        public bool Save(int templateid, string title, string description, int pageNo)
        {
            return pg.Save(templateid, title, description, pageNo);
        }

       

        public bool Update(int templateID, int pageID, string title, string description, int pageNo)
        {
            return pg.Update(templateID, pageID, title, description, pageNo);
        }
    }
}
