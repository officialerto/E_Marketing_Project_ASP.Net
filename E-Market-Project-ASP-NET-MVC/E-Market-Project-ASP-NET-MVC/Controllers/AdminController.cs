using E_Market_Project_ASP_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Market_Project_ASP_NET_MVC.Controllers
{
    public class AdminController : Controller
    {
        dbemarketingEntities db = new dbemarketingEntities();

        [HttpGet]
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // GET: Admin
        public ActionResult Login(tbl_admin avm)
        {
            tbl_admin ad = db.tbl_admin.Where(x => x.ad_username == avm.ad_username && x.ad_password == avm.ad_password).SingleOrDefault();
            if (ad != null)
            {
                Session["ad_id"] = ad.ad_id.ToString();
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
            }
            return View();
        }

        public ActionResult Create()
        {
            if (Session["ad_id"]==null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }
    }

}
