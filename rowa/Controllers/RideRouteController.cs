using rowa.Filters;
using rowa.Models;
using rowa.repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rowa.Controllers
{
    [UserInRole(RoleConsts.Admin)]
    public class RideRouteController : Controller
    {
        public ActionResult CreateRoute()
        {
            return View(new CreateRouteModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRouteModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateRoute", model);
            }

            var temp = model.WayPoints;

            ViewBag.SuccessMessage = "Successfully Created Route";

            return View("CreateRoute", model);
        }
    }
}