using ConscienceLoan.Models;
using ConscienceLoan.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Webdiyer.WebControls.Mvc;
//using X.PagedList;

namespace ConscienceLoan.Controllers
{
    public class FinancialHistoryController : Controller
    {
        //private ConscienceLoanEntities Con = new ConscienceLoanEntities();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexFin2()
        {
            return View();
        }

        public ActionResult AjaxPostFinHistory(int id = 1)
        {
            using (ConscienceLoanEntities Con = new ConscienceLoanEntities())
            {
                Con.Configuration.ProxyCreationEnabled = false;
                List<FinancialRecordsHistory> fin = Con.RecordsHistory(1).ToList<FinancialRecordsHistory>().ToPagedList(id, 100);
                if (Request.IsAjaxRequest()) return PartialView("_AjaxPostFinHistory", fin);
                return View(fin);
            }
        }

        [HttpPost]
        public ActionResult AjaxPostFinHistory(string startTime, string endTime, string searchText, int id = 1)
        {
            return ajaxSearchPostResult(startTime, endTime, searchText, id);
        }
        private ActionResult ajaxSearchPostResult(string startTime, string endTime, string searchText, int id = 1)

        {
            using (var Con = new ConscienceLoanEntities())
            {
                Con.Configuration.ProxyCreationEnabled = false;
                List<FinancialRecordsHistory> qry = null;
                if (!string.IsNullOrWhiteSpace(searchText) && !string.IsNullOrWhiteSpace(startTime) && !string.IsNullOrWhiteSpace(endTime))
                {
                    //根据时间段和指定用户查询所有的交易记录
                    qry = (from row in Con.RecordsHistory(0)
                           where row.FinTimes >= Convert.ToDateTime(startTime).ToLocalTime() && row.FinTimes <= Convert.ToDateTime(endTime).ToLocalTime() && row.TrueName.Equals(searchText)
                           select row).ToList<FinancialRecordsHistory>().ToPagedList(id, 30);
                } else if (!string.IsNullOrWhiteSpace(startTime) && !string.IsNullOrWhiteSpace(endTime))
                {
                    // 如果是根据时间段条件查询的是所有用户最后一次的交易记录
                    qry = (from row in Con.RecordsHistory(1)
                           where Convert.ToDateTime(row.FinTimes) >= Convert.ToDateTime(startTime) && Convert.ToDateTime(row.FinTimes) <= Convert.ToDateTime(endTime)
                           select row).ToList<FinancialRecordsHistory>().ToPagedList(id, 100);
                } else if (!string.IsNullOrWhiteSpace(searchText)){    
                    //根据姓名条件 查询的是指定用户所有的交易记录
                    qry = (from row in Con.RecordsHistory(0)
                           where row.TrueName.Equals(searchText)
                           select row).ToList<FinancialRecordsHistory>().ToPagedList(id, 30);
                }
                else
                {
                    //无任何条件 查询所有用户的最后一次交易记录
                    qry = (from f in Con.RecordsHistory(1) select f).ToList<FinancialRecordsHistory>().ToPagedList(id, 100);
                }
                if (Request.IsAjaxRequest())
                    return PartialView("_AjaxPostFinHistory", qry);
                return View(qry);
                //}
            }
        }
    }
}