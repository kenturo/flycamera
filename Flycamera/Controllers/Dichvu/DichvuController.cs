using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flycamera.Controllers.Dichvu
{
    public class DichvuController : Controller
    {
        //
        // GET: /Dichvu/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detail(int id)
        {
            ViewData["articleId"] = id;
            return View();
        }

        public ActionResult Client()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Teams()
        {
            return View();
        }

    }
}
