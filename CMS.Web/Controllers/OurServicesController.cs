using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class OurServicesController : Controller
    {
        [HttpGet]
        // GET: OurServices
        public ActionResult Index()
        {
            return View();
        }
    }
}