using CuteSurvey.SurveyFactory.Component;
using CuteSurvey.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Survey
{


    public class Page : PageProvider
    {
        public int SurveyID {get;set;}
        public Page(string pageName, string description, int pageNo)
        {
            this.PageID = -1;
            this.PageTitle = pageName;
            this.Description = description;
            this.PageNo = PageNo;
            this.SurveyID = -1;
        }
        public Page(int pageID)
        {
            this.PageID = pageID;
            this.PageTitle = "";
            this.Description = "";
            this.PageNo = -1;
            this.SurveyID = -1;
        }
    }

    public class Pages : ISurveyTemplatePage
    {
        private readonly int surveyID;
        private QueryList<Page> PageList { get; set; }
        public Pages(int surveyID)
        {
            this.surveyID = surveyID;
        }
        public Pages() {
            this.surveyID = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            List<Page> pages;
            DataTable dt = new DataTable();
            dt = PageHandler.Load(this.surveyID);
            pages = dt.toList<Page>(new DataFieldMappings()
                .Add("PageID", "PageID")
                .Add("SurveyID", "SurveyID")
                .Add("PageName", "PageTitle")
                .Add("PageDescription", "Description")
                .Add("PageNo", "PageNo")
                , null);
            foreach (Page p in pages)
            {
                PageList.Add(p);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int getPageNo()
        {
            return PageList.Max(x => x.PageNo) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public Page NewPage(string PageName, string description)
        {
            var v = new Page(PageName, description, getPageNo());
            return v;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public Page GetPage(int pageID)
        {
            return PageList.Search(x => x.PageID == pageID).FirstOrDefault();
        }
        public Page GetLastPage() {
            return PageList.toList().Last();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Page> GetPage(Func<Page, bool> search)
        {
            return PageList.Search(search).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool IsPageExist(Func<Page, bool> search)
        {
            return GetPage(search).Count > 0 ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private void Save(Page page)
        {
            if (IsPageExist(x => x.PageID == page.PageID))
            {
                var gpage = GetPage(page.PageID);
                CuteSurvey.Utility.Common.Combine<Page>(ref gpage, page);
                this.PageHandler.Update(gpage.SurveyID,gpage.PageID,gpage.PageTitle,gpage.Description,gpage.PageNo);
            }
            else
            {
                PageList.Add(page);
            }
            this.PageHandler.Save(page.SurveyID, page.PageTitle, page.Description, page.PageNo);
        }

        public void Save() {
            foreach (Page pg in this.PageList.toList()) {
                Save(pg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public void AddPage(Page page)
        {
            if (IsPageExist(x => x.PageID == page.PageID))
            {
                var gpage = GetPage(page.PageID);
                CuteSurvey.Utility.Common.Combine<Page>(ref gpage, page);
            }
            else
            {
                PageList.Add(page);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RemoveAll()
        {
            if (this.PageHandler.RemoveAll(this.surveyID))
            {
                PageList.Clear();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public bool Rmove(int pageID)
        {
            if (this.PageHandler.Remove(pageID, this.surveyID))
            {
                PageList.Remove(x => x.PageID == pageID);
                return true;
            }
            else return false;
        }

    }
}
