using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using collegefeedbacksystem24.Models;

namespace xyzproject.Controllers
{
    public class homeController : Controller
    {

        CollegeFeedbackSystemEntities db = new CollegeFeedbackSystemEntities();


        [Authorize]
        public ActionResult home()
        {
            return View();
        }


        [Authorize]
        public ActionResult aboutus()
        {

            return View();
        }


        [Authorize]
        public ActionResult contactus()
        {

            return View();
        }


        [Authorize]
        public ActionResult facilites()
        {

            return View();
        }

        [Authorize]
        public ActionResult faculty()
        {

            return View();
        }


        [Authorize]
        public ActionResult Courses()
        {

            return View();
        }


        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(userregistration reg)
        {
            if (ModelState.IsValid)
            {

                db.userregistrations.Add(new userregistration
                {
                    uid = reg.uid,
                    uname = reg.uname,
                    uemail = reg.uemail,
                    upass = reg.upass,
                    crole = reg.crole
                });
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(reg);

        }




        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(userregistration reg)
        {

            var s = db.userregistrations.FirstOrDefault(m => m.uname == reg.uname && m.upass == reg.upass);

            if (s != null)
            {
                FormsAuthentication.SetAuthCookie(reg.uname, true);
                return RedirectToAction("home");
            }

            else
            {
                return RedirectToAction("register");
            }



        }


        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }








    }
}
