using CMS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class SlidesController : Controller
    {
        string uploadPath = ConfigurationManager.AppSettings["UploadPath"];

        [HttpGet]
        // GET: Slides
        public ActionResult Index()
        {
            IEnumerable<Slides> categories = Data.Db.Func.GetSlides();

            return View(categories);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Slides slides = Data.Db.Func.GetSlideById(Convert.ToInt32(id)); // get slide by id

            if (slides == null)
            {
                slides = new Slides(); // new slides

                return View(slides); // return slides
            }
            else
            {
                return View(slides); // return slide
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormCollection form, HttpPostedFileBase imageUrl)
        {
            Slides slides = new Slides();

            TryUpdateModel(slides, form);

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

                slides.imageUrl = imageName;
            }

            Data.Db.Func.SaveOrUpdateSlides(slides, id);

            return RedirectToAction("Index", "Slides");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Data.Db.Func.DeleteCategoryById(Convert.ToInt32(id));

            return RedirectToAction("Index", "Slides");
        }
    }
}