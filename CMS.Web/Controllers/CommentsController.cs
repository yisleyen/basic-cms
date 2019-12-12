using CMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class CommentsController : Controller
    {
        [HttpGet]
        // GET: Comments
        public ActionResult Index()
        {
            IEnumerable<Comments> blogs = Data.Db.Func.GetAllComments();

            return View(blogs);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Comments comments = Data.Db.Func.GetCommentById(Convert.ToInt32(id)); // get comment id

            if (comments == null)
            {
                comments = new Comments(); // new comment

                return View(comments); // return comments
            }
            else
            {
                return View(comments); // return comments
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormCollection form)
        {
            Comments comments = new Comments();

            TryUpdateModel(comments, form);

            int id = Convert.ToInt32(form["id"]);

            Data.Db.Func.SaveOrUpdateComments(comments, id);

            return RedirectToAction("Index", "Comments");
        }
    }
}