using CMS.Data;
using System;
using System.Configuration;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class SiteInfosController : Controller
    {
        string uploadPath = ConfigurationManager.AppSettings["UploadPath"];
        string logoWidth = ConfigurationManager.AppSettings["LogoWidth"];
        string logoHeight = ConfigurationManager.AppSettings["LogoHeight"];

        // GET: SiteInfos
        [HttpGet]
        public ActionResult Index()
        {
            SiteInfos siteInfos = Data.Db.Func.GetSiteInfos(); // get site infos

            if (siteInfos == null)
            {
                siteInfos = new SiteInfos(); // new site infos

                return View(siteInfos); // return site infos
            }
            else
            {
                return View(siteInfos); // return site infos
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormCollection form, HttpPostedFileBase logoUrl)
        {
            SiteInfos siteInfos = new SiteInfos();

            TryUpdateModel(siteInfos, form);

            int id = Convert.ToInt32(form["id"]);

            if (logoUrl != null)
            {
                string logoName = "site-logo.png"; // new file name

                if (System.IO.File.Exists(uploadPath + logoName)) // file control
                {
                    System.IO.File.Delete(uploadPath + logoName);
                }

                WebImage webImage = new WebImage(logoUrl.InputStream);

                webImage.Save(uploadPath + logoName);

                siteInfos.logoUrl = logoName;
            }

            Data.Db.Func.SaveOrUpdateSiteInfos(siteInfos, id);

            return RedirectToAction("Index", "SiteInfos");
        }
    }
}