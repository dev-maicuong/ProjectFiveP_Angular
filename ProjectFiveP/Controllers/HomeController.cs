using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFiveP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Request.Cookies["user_id"] != null)
            {
                var id = Request.Cookies["user_id"].Value.ToString();
                
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}