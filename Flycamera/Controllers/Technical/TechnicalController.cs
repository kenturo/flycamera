using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;
using Flycamera.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;

namespace Flycamera.Controllers.Technical
{
    [OutputCache(CacheProfile = "flycameCaches")]
    public class TechnicalController : BaseController
    {
        readonly IRepositryVideos<Fly_Videos> _reposVideo = null;
        readonly IRepositryBase<Fly_Partnership> _repositoryPartner = null;
        private TechnicalVm _vm;

        public TechnicalController()
        {
            _reposVideo = new VideosDAO();
            IRepositryBase<Fly_Navigation> repositryNav = new NavigationDao();
            _repositoryPartner = new PartnershipDAO();
            _vm = new TechnicalVm();

            List<Fly_Navigation> listNav = repositryNav.getAllItems().ToList();
            ViewData[StaticVariable.Navigation] = listNav;
        }
        //
        // GET: /Technical/

        public ActionResult Index()
        {
            _vm.ListVideos = _reposVideo.getAllItemsByTechnical();
            /*get all data Partnership width picture */
            _vm.ListPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

        public ActionResult Detail(int id)
        {
            _vm.Videos = _reposVideo.getItem(id);
            /*get all data Partnership width picture */
            _vm.ListPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

    }
}
