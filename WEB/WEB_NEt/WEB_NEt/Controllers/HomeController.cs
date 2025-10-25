using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_NEt.Controllers
{
    public class HomeController : Controller
    {
        // Trang chủ: /
        public ActionResult Index() 
        {
            return View();
        }

        // Trang: /Home/Facilities
        public ActionResult Facilities() 
        {
            return View();
        }

        // Trang: /Home/Contact
        public ActionResult Contact() 
        {
            return View();
        }
    }
}