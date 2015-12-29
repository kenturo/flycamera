using System.Web.Mvc;
using System.Web.Routing;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ProductGalleryOverviewCreate",
                "Administrator/ProductGallery/{catepage}/{action}/Create",
                new { controller = "ProductGallery", catepage = "overview", action = "Create" }
            );

            context.MapRoute(
                "ProductGalleryFeaturiesCreate",
                "Administrator/ProductGallery/{catepage}/{action}/Create",
                new { controller = "ProductGallery", catepage = "feature", action = "Create" }
            );

            context.MapRoute(
                "ProductGalleryOverviewEdit",
                "Administrator/ProductGallery/{catepage}/Edit/{id}",
                new { controller = "ProductGallery", catepage = "overview", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "ProductGalleryFeaturiesEdit",
                "Administrator/ProductGallery/{catepage}/Edit/{id}",
                new { controller = "ProductGallery", catepage = "feature", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "ProductGalleryOverviewIndex",
                "Administrator/ProductGallery/{catepage}/{action}",
                new { controller = "ProductGallery", catepage = "overview", action = "Index" }
            );

            context.MapRoute(
                "ProductGalleryFeaturiesIndex",
                "Administrator/ProductGallery/{catepage}/{action}",
                new { controller = "ProductGallery", catepage = "feature", action = "Index" }
            );

            

            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );


            
        }
    }
}
