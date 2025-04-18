using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using collegefeedbacksystem24.Models;

namespace xyzproject.Controllers
{
    public class feedbackController : Controller
    {

        CollegeFeedbackSystemEntities db = new CollegeFeedbackSystemEntities();


        [Authorize]
        public ActionResult feedback()
        {
            return View();
        }




        [HttpPost]

        public ActionResult feedback(feedback f)
        {
            if (ModelState.IsValid)
            {

                db.feedbacks.Add(f);
                int i = db.SaveChanges();

                if (i > 0)
                {

                    return RedirectToAction("home", "home");
                }

            }



            return View();
        }


        [Authorize]
        public ActionResult feedbacks()
        {
            var s = db.feedbacks.ToList();

            return View(s);
        }


        [Authorize]
        public ActionResult details(int id)
        {
            var s = db.feedbacks.FirstOrDefault(m => m.StudentId == id);

            return View(s);
        }

        [Authorize]
        public ActionResult delete(int id)
        {
            var s = db.feedbacks.FirstOrDefault(m => m.StudentId == id);

            return View(s);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var feedback = db.feedbacks.FirstOrDefault(f => f.StudentId == id);
            if (feedback != null)
            {
                db.feedbacks.Remove(feedback);
                db.SaveChanges();
            }
            return RedirectToAction("Feedbacks");
        }



    }
}
