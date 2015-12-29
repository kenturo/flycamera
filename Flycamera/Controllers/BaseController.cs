using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Flycamera.Controllers
{
    public class BaseController : Controller
    {
        protected override void ExecuteCore()
        {
            var culture = Session["lang"] ?? "vi";

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.ToString());
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            Session["lang"] = culture.ToString();

            base.ExecuteCore();
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}
