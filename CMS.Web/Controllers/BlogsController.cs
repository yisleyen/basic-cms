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
    public class BlogsController : Controller
    {
        string uploadPath = ConfigurationManager.AppSettings["UploadPath"];

        [HttpGet]
        // GET: Blogs
        public ActionResult Index()
        {
            IEnumerable<Blogs> blogs = Data.Db.Func.GetBlogs();

            return View(blogs);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Blogs blogs = Data.Db.Func.GetBlogById(Convert.ToInt32(id)); // get blog id

            if (blogs == null)
            {
                blogs = new Blogs(); // new blogs

                return View(blogs); // return blogs
            }
            else
            {
                return View(blogs); // return blogs
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, HttpPostedFileBase imageUrl)
        {
            Blogs blogs = new Blogs();

            TryUpdateModel(blogs, form);

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

                blogs.imageUrl = imageName;
            }

            Data.Db.Func.SaveOrUpdateBlogs(blogs, id);

            return RedirectToAction("Index", "Blogs");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Data.Db.Func.DeleteBlogById(Convert.ToInt32(id));

            return RedirectToAction("Index", "Blogs");
        }
    }
}