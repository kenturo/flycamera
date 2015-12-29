using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flycamera.Controllers.Notfound
{
    [HandleError()]
    public class ErrorController : BaseController
    {
        public ViewResult Error()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("Error");
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 500;  //you may want to set this to 200
            return View("Error");
        }

        public ActionResult Index(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            return View("Error");
        }
    }
}
