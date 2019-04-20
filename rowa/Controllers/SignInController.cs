using rowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rowa.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(SignInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            return View("Index");
        }
    }
}