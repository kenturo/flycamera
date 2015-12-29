using System.Web;
using System.Web.Optimization;

namespace Flycamera
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/fileupload").Include(
                        "~/Scripts/jquery-1.11.2.js",
                        "~/Scripts/fileupload/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                        "~/Scripts/fancybox/jquery.fancybox.js",
                        "~/Scripts/fancybox/jquery.fancybox.pack.js",
                        "~/Scripts/fancybox/*.js"));

            /* Bundle CSS For Mainsite */
            bundles.Add(new ScriptBundle("~/Scripts/MainsiteJS").Include(
                        "~/Scripts/parallax-bg.js",
                        "~/Scripts/ckfinder/ckfinder.js",
                        "~/Scripts/jquery.jcarousel.js",
                        "~/Scripts/jquery.jcarousel.js",
                        "~/Scripts/jquery.reel.js",
                        "~/Scripts/idangerous.swiper.js",
                        "~/Scripts/kendo/kendo.all.js",
                        "~/Scripts/helper.js",
                        "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/Scripts/AdminJS").Include(
                        "~/Scripts/kendo/kendo.all.js",
                        "~/Scripts/ckfinder/ckfinder.js",
                        "~/Scripts/tinymce/tinymce.js",
                        "~/Scripts/helper.js",
                        "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/Scripts/AngularJS").Include(
                        "~/Scripts/jquery.jcarousel.js",
                        "~/Scripts/moduleAngular.js",
                        "~/Scripts/angular/common.js"));


            bundles.Add(new ScriptBundle("~/Scripts/JSMobile").Include(
                        "~/Scripts/common-m.js"));



            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/style.css",
                        "~/Content/css/parallax-bg.css"));

            bundles.Add(new StyleBundle("~/Content/fancybox").Include(
                        "~/Content/css/fancybox/jquery.fancybox.css",
                        "~/Content/css/fancybox/*.css"));


            


            /* Bundle CSS For Mainsite */
            bundles.Add(new StyleBundle("~/Content/MainsiteCSS").Include(
                        "~/Content/css/kendo/*.css",
                        "~/Content/css/fancybox/jquery.fancybox.css",
                        "~/Content/css/fancybox/*.css",
                        "~/Content/css/social-style-vr3.css",
                        "~/Content/css/tables.css",
                        "~/Content/css/style.css",
                        "~/Content/css/parallax-bg.css"));

            /* Bundle CSS For Administrator */
            bundles.Add(new StyleBundle("~/Content/CSSMobile").Include(
                        "~/Content/css/style-mobile.css"));


            /* Bundle CSS For Administrator */
            bundles.Add(new StyleBundle("~/Content/AdminCSS").Include(
                        "~/Content/css/kendo/*.min",
                        "~/Content/css/tables.css",
                        "~/Content/css/style-admin.css"));


            /* Bundle CSS For Administrator */
            bundles.Add(new StyleBundle("~/Content/AngularCSS").Include(
                        "~/Content/css/jcarousel.basic.css",
                        "~/Content/css/angular/home.css"));


        }
    }
}