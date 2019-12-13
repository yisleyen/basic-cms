using CMS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();

            return View();
        }

        [HttpGet]
        [Route("about-us")]
        public ActionResult AboutUs()
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();
            AboutUs aboutUs = Data.Db.Func.GetAboutUs();
            
            return View(aboutUs);
        }

        [HttpGet]
        [Route("our-services")]
        public ActionResult OurServices()
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();
            return View();
        }

        [HttpGet]
        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();
            Contact contact = Data.Db.Func.GetContact();

            return View(contact);
        }

        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            string To = ConfigurationManager.AppSettings["To"];
            string SmtpDisplayName = ConfigurationManager.AppSettings["SmtpDisplayName"];
            string SmtpPass = ConfigurationManager.AppSettings["SmtpPass"];
            string SmtpPort = ConfigurationManager.AppSettings["SmtpPort"];
            string SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            string SmtpUser = ConfigurationManager.AppSettings["SmtpUser"];

            string name = form["name"];
            string email = form["email"];
            string subject = form["subject"];
            string message = form["message"];

            string newMessage = "<strong>Adı:</strong> " + name + "<br>";
            newMessage += "<strong>E-posta adresi:</strong> " + email + "<br>";
            newMessage += "<strong>Mesaj içeriği:</strong> " + message + "<br>";

            List<string> to = new List<string>
            {
                To
            };

            Data.Helper.EmailObject emailObject = new Data.Helper.EmailObject();
            emailObject.To = to;
            emailObject.Subject = subject;
            emailObject.Message = newMessage;

            Data.Helper.EmailHelper emailHelper = new Data.Helper.EmailHelper();
            emailHelper.SmtpDisplayName = SmtpDisplayName;
            emailHelper.SmtpPass = SmtpPass;
            emailHelper.SmtpPort = Convert.ToInt32(SmtpPort);
            emailHelper.SmtpServer = SmtpServer;
            emailHelper.SmtpUser = SmtpUser;

            try
            {
                emailHelper.SendEmail(emailObject);

                ViewBag.Message = "Mesajınız gönderildi, teşekkürler!";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Mesajınız gönderilirken bir hata oluştu. Lütfen tekrar deneyin.";
            }

            return View();
        }

        [HttpGet]
        [Route("blog")]
        public ActionResult Blog()
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();
            return View();
        }

        [HttpGet]
        [Route("blog/{title}/{id:int}")]
        public ActionResult CategoryBlog(int id)
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();
            IEnumerable<Blogs> blogs = Data.Db.Func.GetBlogByCategoryId(id);

            return View(blogs);
        }

        [HttpGet]
        [Route("blog/{title}-{id:int}")]
        public ActionResult BlogDetails(int id)
        {
            ViewBag.SiteInfos = Data.Db.Func.GetSiteInfos();
            Blogs blog = Data.Db.Func.GetBlogById(id);

            return View(blog);
        }

        [HttpPost]
        public ActionResult CommentSave(FormCollection form)
        {
            Comments comments = new Comments();

            TryUpdateModel(comments, form);

            int id = Convert.ToInt32(form["id"]);

            Data.Db.Func.SaveOrUpdateComments(comments, id);

            ViewBag.Message = "Yorumunuz kayıt edilmiştir, onay işleminden sonra yayınlanacaktır.";

            return RedirectToAction("BlogDetails/" + form["blogid"], "Home");
        }

        public ActionResult CategoryPartial()
        {
            IEnumerable<Categories> categories = Data.Db.Func.GetCategories();

            return PartialView(categories);
        }

        public ActionResult LatestPostPartial()
        {
            IEnumerable<Blogs> blogs = Data.Db.Func.GetBlogs();

            return PartialView(blogs);
        }

        public ActionResult SiteFooter()
        {
            Contact contact = Data.Db.Func.GetContact();
            SiteInfos siteInfos = Data.Db.Func.GetSiteInfos();

            Tuple<Contact, SiteInfos> model = new Tuple<Contact, SiteInfos>(contact, siteInfos);

            return PartialView(model);
        }

        public ActionResult SiteHeader()
        {
            SiteInfos siteInfos = Data.Db.Func.GetSiteInfos();

            return PartialView(siteInfos);
        }
    }
}