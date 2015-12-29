using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Flycamera
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "newDichVu",
                url: "dich-vu/{action}",
                defaults: new
                {
                    controller = "Dichvu",
                    action = UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "detaildichvu",
                url: "dich-vu/bai-viet/{article_name}-{id}",
                defaults: new
                {
                    controller = "Dichvu",
                    action = "Detail",
                    article_name = UrlParameter.Optional,
                    id = UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "newProduct",
                url: "product/{action}/{product_name}-{id}",
                defaults: new
                {
                    controller = "Product",
                    action = UrlParameter.Optional,
                    product_name = UrlParameter.Optional,
                    id = UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "Payment",
                url: "Payment/{cusId}/{productId}",
                defaults:
                    new
                    {
                        area = "",  
                        controller = "Payment",
                        action = "Index",
                        cusId = UrlParameter.Optional,
                        productId = UrlParameter.Optional
                    }
                );

            routes.MapRoute(
               name: "newAccessories",
               url: "accessories/{product_name}-{id}",
               defaults:
                   new
                   {
                       controller = "Accessories",
                       action = "index",
                       product_name = UrlParameter.Optional,
                       id = UrlParameter.Optional
                   }
               );

            routes.MapRoute(
               name: "detailTechnical",
               url: "technical/{title_name}-{id}",
               defaults:
                   new
                   {
                       controller = "Technical",
                       action = "Detail",
                       title_name = UrlParameter.Optional,
                       id = UrlParameter.Optional
                   }
               );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { area = "", controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Flycamera.Controllers" }
                );

            
        }
    }
}