using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class AboutUsController : Controller
    {
        [HttpGet]
        // GET: AboutUs
        public ActionResult Index()
        {
            AboutUs aboutUs = Data.Db.Func.GetAboutUs(); // get about us info

            if (aboutUs == null)
            {
                aboutUs = new AboutUs(); // new about us

                return View(aboutUs); // return about us info
            }
            else
            {
                return View(aboutUs); // return about us info
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form)
        {
            AboutUs aboutUs = new AboutUs();

            TryUpdateModel(aboutUs, form);

            int id = Convert.ToInt32(form["id"]);

            Data.Db.Func.SaveOrUpdateAboutUs(aboutUs, id);

            return RedirectToAction("Index", "AboutUs");
        }
    }
}