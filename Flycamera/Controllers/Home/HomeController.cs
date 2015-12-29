using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity.DataAccess;
using FlyEntity;
using System.Dynamic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Flycamera.App_Start;
using FlyEntity.Utilities;
using Flycamera.ViewModel;
using FlyEntity.Repositry;

namespace Flycamera.Controllers.Home
{
//    [HandleError()]
    public class HomeController : BaseController
    {
        HomeVM _vm = null;
        readonly IRepositryBase<Fly_Banner> _repositoryBanner = null;
        readonly IRepositryVideos<Fly_Videos> _repositoryVideos = null;
        readonly IRepositryBase<Fly_Partnership> _repositoryPartner = null;
        readonly IRepositryBase<Fly_Navigation> _repositryNav = null;


        public HomeController()
        {
            _repositoryBanner = new BannerDAO();
            _repositoryVideos = new VideosDAO();
            _repositoryPartner = new PartnershipDAO();
            _repositryNav = new NavigationDao();
            _vm = new HomeVM();
        }


        //
        // GET: /Home/

//        [OutputCache(CacheProfile = "flycameCaches")]
        public ActionResult Index()
        {
            try
            {
                /*get all data banner width picture */
                _vm.listBanner = _repositoryBanner.getAllItems().Where(x => x.Published == true && x.Fly_BannerType.BannerTypeTitle.Equals("Banner Home")).Take(ConfiguationSite.NumberBanner).ToList();

                /*get all data video width picture */
                _vm.listVideo = _repositoryVideos.getAllItemsByHome().Take(ConfiguationSite.NumberVideoHome).ToList();

                /*get all data Partnership width picture */
                _vm.listPartnerships = _repositoryPartner.getAllItems().Where(x=>x.Published == true).ToList();

                List<Fly_Navigation> listNav = _repositryNav.getAllItems().Take(ConfiguationSite.NumberItemNavigation).ToList();
                ViewData[StaticVariable.Navigation] = listNav;


                /*pass data to partialView by ViewData */
                ViewData[StaticVariable.BannerHome] = _vm.listBanner;
                ViewData[StaticVariable.VideoHome] = _vm.listVideo;
                ViewData[StaticVariable.PartnerShip] = _vm.listPartnerships;
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public ActionResult ChangeLanguage(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            Session["lang"] = culture;

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
