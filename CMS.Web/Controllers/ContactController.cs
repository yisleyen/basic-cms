using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        // GET: Contact
        public ActionResult Index()
        {
            Contact contact = Data.Db.Func.GetContact(); // get contact info

            if (contact == null)
            {
                contact = new Contact(); // new contact

                return View(contact); // return contact info
            }
            else
            {
                return View(contact); // return contact info
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form)
        {
            Contact contact = new Contact();

            TryUpdateModel(contact, form);

            int id = Convert.ToInt32(form["id"]);

            Data.Db.Func.SaveOrUpdateContact(contact, id);

            return RedirectToAction("Index", "Contact");
        }
    }
}