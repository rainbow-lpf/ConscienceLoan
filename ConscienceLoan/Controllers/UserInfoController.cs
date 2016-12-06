using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConscienceLoan.Models;
using System.Web.Script.Serialization;
using Webdiyer.WebControls.Mvc;
//using X.PagedList;

namespace ConscienceLoan.Controllers
{
    public class UserInfoController : Controller
    {
        //private ConscienceLoanEntities Con = new ConscienceLoanEntities();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        [HttpGet]
        public ActionResult Index(string name = "", int id = 1)
        {
            try
            {
                using (var Con = new ConscienceLoanEntities())
                {
                    Con.Configuration.ProxyCreationEnabled = false;
                    if (name == "" || name == "undefined")
                    {
                        var Users = Con.UserInfo.ToList().ToPagedList(id, 100);
                        ViewBag.Users = js.Serialize(Users);
                        ViewBag.Search = true;
                        return View(Users);
                    }
                    var UsersCon = Con.UserInfo.Where(u => u.TrueName.Equals(name)).ToList().ToPagedList(id, 100);
                    ViewBag.Users = js.Serialize(UsersCon);
                    ViewBag.Search = false;
                    return View(UsersCon);
                }
            }
            catch (Exception ex)
            {
                return Content("<scirpt>alert('" + ex.ToString() + "')</scirpt>");
            }

        }
        public ActionResult Index2(string name = "")
        {
            using (var Con = new ConscienceLoanEntities())
            {
                Con.Configuration.ProxyCreationEnabled = false;
                if (name == "" || name == "undefined")
                {
                    var Users = Con.UserInfo.ToList();
                    ViewBag.Users = js.Serialize(Users);
                    return View(Users);
                }
                var UsersCon = Con.UserInfo.Where(u => u.TrueName.Equals(name)).ToList();
                ViewBag.Users = js.Serialize(UsersCon);
                return View(UsersCon);
            }
        }
        public ActionResult DeleteUsers(List<UserInfo> users)
        {
            using (var Con = new ConscienceLoanEntities())
            {
                try
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        UserInfo user = new UserInfo();
                        user.UserID = users[i].UserID;
                        Con.UserInfo.Attach(user);
                        Con.UserInfo.Remove(user);
                    }
                    Con.SaveChanges();

                }
                catch (Exception ex)
                {
                    return Content("2");

                }
                return Content("1");
            }
        }
        public ActionResult AddUser(UserInfo user)
        {
            using (var Con = new ConscienceLoanEntities())
            {
                try
                {
                    Con.UserInfo.Add(user);
                    Con.SaveChanges();
                    return Content("1");
                }
                catch (Exception ex)
                {
                    return Content("2");
                }
            }
        }
        public ActionResult UpdateUser(UserInfo user)
        {
            using (var Con = new ConscienceLoanEntities())
            {
                try
                {
                    UserInfo us = Con.UserInfo.Where(u => u.UserID == user.UserID).FirstOrDefault();
                    UpdateModel(us);
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