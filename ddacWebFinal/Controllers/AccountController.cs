using ddacWebFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddacWebFinal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(loginViewModel lvm)
        {
            var user = new User();
            using (Model1Container context = new Model1Container())
            {
                user = context.Users.Where(a => a.username == lvm.username && a.password == lvm.password).FirstOrDefault();
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password!");
            }
            else
            {
                Session["User"] = user;
                ModelState.AddModelError("", "Successful");
                return RedirectToAction("Index", "Home");
                //("Index = Page", "Home = Controller")
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}