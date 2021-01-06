using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFiveP.Areas.Admin.Controllers
{
    public class ViewAdminController : Controller
    {
        // GET: Admin/ViewAdmin
        public PartialViewResult Menu()
        {
            return PartialView();
        }
        public PartialViewResult Vali()
        {
            return PartialView();
        }
    }
}