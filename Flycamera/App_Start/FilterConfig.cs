using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;

namespace Flycamera
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}