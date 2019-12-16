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
        public ActionResult Index()
        {
            IEnumerable<Admins> users = Data.Db.Func.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Admins admins = Data.Db.Func.GetUserById(Convert.ToInt32(id)); // get admin by id

            if (admins == null)
            {
                admins = new Admins(); // new admins

                return View(admins); // return admins
            }
            else
            {
                return View(admins); // return admins
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormCollection form)
        {
            Admins admins = new Admins();

            TryUpdateModel(admins, form);

            int id = Convert.ToInt32(form["id"]);

            admins.password = Data.Helper.CryptoHelper.GetMD5Hash(form["password"]);

            Data.Db.Func.SaveOrUpdateCategories(admins, id);

            string authority = (string)(Session["Authority"]);

            if (authority == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Data.Db.Func.DeleteUserById(Convert.ToInt32(id));

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string message = string.Empty;

            IEnumerable<Admins> user = Data.Db.Func.ValidateUser(form["email"], Data.Helper.CryptoHelper.GetMD5Hash(form["password"]));

            if (user.Count() > 0)
            {
                foreach (var item in user)
                {
                    Session["NameLastName"] = item.name + " " + item.surname;
                    Session["Email"] = item.email;
                    Session["Id"] = item.id;
                    Session["Authority"] = item.authority;
                }

                Session["CommentsCount"] = Data.Db.Func.GetPassiveCommentCount();

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