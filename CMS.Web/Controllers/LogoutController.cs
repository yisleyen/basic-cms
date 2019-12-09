using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet]
        // GET: Logout
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Admin");
        }
    }
}