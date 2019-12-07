using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet]
        // GET: Categories
        public ActionResult Index()
        {
            IEnumerable<Categories> categories = Data.Db.Func.GetCategories();

            return View(categories);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Categories categories = Data.Db.Func.GetCategoryById(Convert.ToInt32(id)); // get category by id

            if (categories == null)
            {
                categories = new Categories(); // new categories

                return View(categories); // return categories
            }
            else
            {
                return View(categories); // return categories
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form)
        {
            Categories categories = new Categories();

            TryUpdateModel(categories, form);

            int id = Convert.ToInt32(form["id"]);

            Data.Db.Func.SaveOrUpdateCategories(categories, id);

            return RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Data.Db.Func.DeleteCategoryById(Convert.ToInt32(id));

            return RedirectToAction("Index", "Categories");
        }
    }
}