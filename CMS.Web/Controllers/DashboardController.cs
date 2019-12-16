using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        // GET: Dashboard
        public ActionResult Index()
        {
            IEnumerable<Categories> categories = Data.Db.Func.GetCategories();
            ViewBag.CategoryCount = categories.Count();

            IEnumerable<Blogs> blogs = Data.Db.Func.GetBlogs();
            ViewBag.BlogCount = blogs.Count();

            IEnumerable<OurServices> ourServices = Data.Db.Func.GetServices();
            ViewBag.OurServiceCount = ourServices.Count();

            IEnumerable<Comments> comments = Data.Db.Func.GetComments();
            ViewBag.CommentCount = comments.Count();

            return View();
        }
    }
}