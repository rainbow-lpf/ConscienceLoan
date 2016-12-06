using ConscienceLoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ConscienceLoan.Controllers
{
    public class TenderController : Controller
    {
        //private ConscienceLoanEntities Con = new ConscienceLoanEntities();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Tender
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTender(Tender  ten)
        {
            using (var Con=new ConscienceLoanEntities()) { 
                try
                {
                    Con.Tender.Add(ten);
                    Con.SaveChanges();
                    return Content("1");
                }
                catch (Exception ex)
                {
                    return Content("2");
                }
            }
        }

        public ActionResult TenderManger()
        {
            return View();
        }
    }
}