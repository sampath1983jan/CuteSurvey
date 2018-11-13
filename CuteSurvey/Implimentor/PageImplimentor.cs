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

namespace CuteSurvey.Implimentor
{
    public class PageImplimentor : IPage
    {

        string conn = "SslMode=none;persistsecurityinfo=True;SERVER=localhost;UID=root;DATABASE=cutesurvey;PASSWORD=admin312;";
        public DataTable Load(int SuveyTemplateID)
        {
            DataTable dt = new DataTable();
            Data.Pages pg = new Data.Pages(conn);
            dt = pg.GetPages(SuveyTemplateID);
            return dt;
        }
        public bool Remove(int pageID,int surveyTemplateID)
        {
            Data.Pages pg = new Data.Pages(conn);
            return pg.Remove(surveyTemplateID, pageID);
        }
        public bool RemoveAll(int surveyTemplateID)
        {
            Data.Pages pg = new Data.Pages(conn);
           return pg.RemoveAll(surveyTemplateID);
        }
        public bool Save(Page page)
        {
            Data.Pages pg = new Data.Pages(conn);
            return pg.Save(page.SurveyTemplateID, page.PageTitle, page.Description, page.PageNo);
        }       
        public bool Update(Page page)
        {
            Data.Pages pg = new Data.Pages(conn);
            return pg.Update(page.SurveyTemplateID, page.PageID, page.PageTitle, page.Description, page.PageNo);
        }
    }
}
