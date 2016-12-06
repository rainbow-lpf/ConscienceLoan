using ConscienceLoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Webdiyer.WebControls.Mvc;

namespace ConscienceLoan.Controllers
{
    public class FinancialRecordsController : Controller
    {
        //private ConscienceLoanEntities Con = new ConscienceLoanEntities();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        [HttpGet]
        public ActionResult Index(string name="", int id = 1)
        {
            using (var Con = new ConscienceLoanEntities())
            {
                Con.Configuration.ProxyCreationEnabled = false;
                List<FinancialRecordsHistory> fin = null;
                if (name == "" || name == "undefined")
                {
                    fin = Con.FinancialRecordsHistories.ToList().ToPagedList(id, 100);
                    ViewBag.Fin = js.Serialize(fin);
                    ViewBag.Search = true;
                    return View(fin);
                }
                fin = Con.FinancialRecordsHistories.Where(f => f.TrueName.Equals(name)).ToList().ToPagedList(id, 100);
                ViewBag.Fin = js.Serialize(fin);
                ViewBag.Search = false;
                return View(fin);
            }
        }
        /// <summary>
        /// 资金操作
        /// </summary>
        /// <param name="fin"></param>
        /// <returns></returns>
        public ActionResult UpdateFin(FinancialRecords fin)
        {
            using (var Con = new ConscienceLoanEntities())
            {
                try
                {
                    FinancialRecords finan = Con.FinancialRecords.Where(f => f.FinID.Equals(fin.FinID)).FirstOrDefault();
                    UpdateModel(finan);
                    fin.FinTimes = DateTime.Now;
                    Con.FinancialRecords.Add(fin);
                    Con.SaveChanges();
                    return Content("1");
                }
                catch (Exception ex)
                {

                    return Content("2");
                }
            }
        }
    }
}