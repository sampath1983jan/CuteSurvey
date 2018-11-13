using CuteSurvey.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory.Component
{
    public interface IPage {
        DataTable Load(int SuveyTemplateID);
        bool Save(Page page);
        bool Update(Page page);
        bool Remove(int pageID,int surveyTemplateID);
        bool RemoveAll(int surveyTemplateID);
    }

    public abstract class ISurveyTemplatePage {
        public IPage PageHandler;
    }

    public class Page 
    {
        public int PageID { get; set; }
        public int SurveyTemplateID {get;set;}
        public int PageNo { get; set; }
        public string PageTitle { get; set; }
        public string Description { get; set; }
        private int PageOrder { get; set; }
        public Page() {

        }
        public Page(string pageName, string description, int pageNo) {
            this.PageID = -1;
            this.PageTitle = pageName;
            this.Description = description;
            this.PageNo = PageNo;
        }
        public Page(int pageID) {
            this.PageID = pageID;
        }
    }

    public class Pages: ISurveyTemplatePage
    {
        /// <summary>
        ///     
        /// </summary>
        private readonly int SurveyTemplateID;
        /// <summary>
        /// 
        /// </summary>
        private QueryList<Page> PageList { get; set; }

        public void Load() {
            List<Page> pages;
            DataTable dt = new DataTable();
            dt = PageHandler.Load(SurveyTemplateID);
            pages = dt.toList<Page>(new DataFieldMappings()
                .Add("PageID", "PageID")
                .Add("SurveyTemplateID", "SurveyTemplateID")
                .Add("PageName", "PageTitle")
                .Add("PageDescription", "Description")
                .Add("PageNo", "PageNo")
                , null);
            foreach (Page p in pages)
            {
                PageList.Add(p);
            }
        }
        public Pages() {
            this.SurveyTemplateID = -1;
        }
        public Pages(int surveyTemplateID) {
            this.SurveyTemplateID = surveyTemplateID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int getPageNo() {
             return PageList.Max(x => x.PageNo) + 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public Page NewPage(string PageName, string description) {
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
        public void Save(Page page) {
            if (IsPageExist(x => x.PageID == page.PageID))
            {
                var gpage = GetPage(page.PageID );
                CuteSurvey.Utility.Common.Combine<Page>(ref gpage, page);
                this.PageHandler.Update(gpage);
            }
            else
            {
                PageList.Add(page);
            }
            this.PageHandler.Save(page);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public void AddPage(Page page) {
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
        public bool RemoveAll() {
            if (this.PageHandler.RemoveAll(this.SurveyTemplateID))
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
        public bool  Rmove(int pageID) {
            if (this.PageHandler.Remove(pageID,this.SurveyTemplateID)) {
              PageList.Remove(x => x.PageID == pageID);
                return true;
            }else return false ;
        }


    }
}
