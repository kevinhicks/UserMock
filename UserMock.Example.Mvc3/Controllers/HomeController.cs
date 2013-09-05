using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserMock.Example.Mvc3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult SecureArea()
        {
            ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
            return View();
        }
    }
}
