using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using X.PagedList;

namespace ConscienceLoan.Models
{
    public class PagedClientViewModel
    {
        public int Page { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string SearchText { get; set; }
        public int pageSize { get; set; }
        //public IPagedList<object> Clients
        //{
        //    get; set;
        //}
        public PagedClientViewModel()
        {

        }
        public PagedClientViewModel(int Page, int pageSize, string startTime,string endTime, string searchText)
        {
            this.Page = Page;
            this.pageSize = pageSize;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.SearchText = searchText;
        }
       
    }
}