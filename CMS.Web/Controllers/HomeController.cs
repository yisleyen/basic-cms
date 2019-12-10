using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            AboutUs aboutUs = Data.Db.Func.GetAboutUs();

            return View(aboutUs);
        }

        [HttpGet]
        public ActionResult OurServices()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            Contact contact = Data.Db.Func.GetContact();

            return View(contact);
        }

        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            return View();
        }

        [HttpGet]
        public ActionResult SiteFooter()
        {
            Contact contact = Data.Db.Func.GetContact();
            SiteInfos siteInfos = Data.Db.Func.GetSiteInfos();

            Tuple<Contact, SiteInfos> model = new Tuple<Contact, SiteInfos>(contact, siteInfos);

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult SiteHeader()
        {
            SiteInfos siteInfos = Data.Db.Func.GetSiteInfos();

            return PartialView(siteInfos);
        }
    }
}