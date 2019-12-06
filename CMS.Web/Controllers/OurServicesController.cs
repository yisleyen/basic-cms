using CMS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class OurServicesController : Controller
    {
        string uploadPath = ConfigurationManager.AppSettings["UploadPath"];

        [HttpGet]
        // GET: OurServices
        public ActionResult Index()
        {
            IEnumerable<OurServices> ourServices = Data.Db.Func.GetServices();

            return View(ourServices);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            OurServices ourServices = Data.Db.Func.GetOurServiceById(Convert.ToInt32(id)); // get our service by id

            if (ourServices == null)
            {
                ourServices = new OurServices(); // new our services

                return View(ourServices); // return our services
            }
            else
            {
                return View(ourServices); // return our services
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, HttpPostedFileBase imageUrl)
        {
            OurServices ourServices = new OurServices();

            TryUpdateModel(ourServices, form);

            int id = Convert.ToInt32(form["id"]);

            if (imageUrl != null)
            {
                WebImage webImage = new WebImage(imageUrl.InputStream);

                string extension = "." + webImage.ImageFormat;

                string imageName = Extensions.ToUrlSlug(form["title"]) + extension; // new file name

                if (System.IO.File.Exists(uploadPath + imageName)) // file control
                {
                    System.IO.File.Delete(uploadPath + imageName);
                }

                webImage.Save(uploadPath + imageName);

                ourServices.imageUrl = imageName;
            }

            Data.Db.Func.SaveOrUpdateOurServices(ourServices, id);

            return RedirectToAction("Index", "OurServices");
        }

        public ActionResult Delete(string id)
        {
            Data.Db.Func.DeleteOurServicesById(Convert.ToInt32(id));

            return RedirectToAction("Index", "OurServices");
        }
    }
}