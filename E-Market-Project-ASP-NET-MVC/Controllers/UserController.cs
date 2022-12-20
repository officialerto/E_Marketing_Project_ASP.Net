using E_Market_Project_ASP_NET_MVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Market_Project_ASP_NET_MVC.Controllers
{
    public class UserController : Controller
    {
        dbemarketingEntities db = new dbemarketingEntities();

        // GET: User
        public ActionResult Index(int ?page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_category.Where(x => x.cat_status == 1).OrderByDescending(x => x.cat_id).ToList();
            IPagedList<tbl_category> stu = list.ToPagedList(pageindex, pagesize);

            return View(stu);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(tbl_user uvm, HttpPostedFileBase imgfile) 
        {
            string path = uploadingfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded..";
            }
            else
            {

                tbl_user u = new tbl_user();
                u.u_name = uvm.u_name;
                u.u_email = uvm.u_email;
                u.u_password = uvm.u_password;
                u.u_contact = uvm.u_contact;
                u.u_image = path;
                db.tbl_user.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login");

            }

                return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // GET: Admin
        public ActionResult Login(tbl_user avm)
        {
            tbl_user ad = db.tbl_user.Where(x => x.u_email == avm.u_email && x.u_password == avm.u_password).SingleOrDefault();
            if (ad != null)
            {
                Session["u_id"] = ad.u_id.ToString();
                return RedirectToAction("CreateAd");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
            }
            return View();
        }


        public string uploadingfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }



            return path;
        }

        public ActionResult CreateAd()
        {
            return View();
        }


    }
}