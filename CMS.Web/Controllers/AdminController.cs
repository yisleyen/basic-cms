using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string message = string.Empty;

            IEnumerable<Admins> user = Data.Db.Func.ValidateUser(form["email"], form["password"]);

            if (user.Count() > 0)
            {
                foreach (var item in user)
                {
                    Session["NameLastName"] = item.name + " " + item.surname;
                    Session["Email"] = item.email;
                    Session["Id"] = item.id;
                    Session["Authority"] = item.authority;
                }

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Message = "E-posta adresinizi ya da şifrenizi hatalı girdiniz.";

                return View();
            }
        }
    }
}