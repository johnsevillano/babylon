using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Babylon.Site.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Babylon!";

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }
    }
}
