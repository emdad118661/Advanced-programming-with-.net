using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1st_web_practice.Controllers
{
    public class CVController : Controller
    {
        // GET: CV
        public ActionResult List()
        {
            return View();
        }
    }
}