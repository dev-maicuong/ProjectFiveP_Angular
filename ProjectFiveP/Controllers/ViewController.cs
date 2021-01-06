using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFiveP.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        public PartialViewResult Vali()
        {
            return PartialView();
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}