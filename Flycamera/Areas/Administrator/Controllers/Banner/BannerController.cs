using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;
namespace Flycamera.Areas.Administrator.Controllers.Banner
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class BannerController : Controller
    {
        readonly IRepositryBase<Fly_Banner> _repository = null;
        readonly IRepositryBase<Fly_BannerType> _repoType = null;
        readonly BannerModel _bannerModel = null;


        // contructor
        public BannerController()
        {
            _repository = new BannerDAO();
            _repoType = new BannerTypeDAO();
            _bannerModel = new BannerModel();
        }

        //
        // GET: /Banner/

        public ActionResult Index()
        {
            IList<Fly_Banner> bn = new List<Fly_Banner>();
            try
            {

                bn = _repository.getAllItems();
                return View(bn);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Banner/Create

        public ActionResult Create()
        {
            _bannerModel.PositionBannerType = _repoType.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.BannerTypeID.ToString(),
                    Text = x.BannerTypeTitle
                });
            return View(_bannerModel);
        }

        //
        // POST: /Banner/Create

        [HttpPost]
        public ActionResult Create(BannerModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                obj.banner.CreatedOn = DateTime.Now;
                obj.banner.Deleted = obj.isDelete;
                obj.banner.Published = obj.isPublish;
                obj.banner.BannerTypeID = obj.positionType;

                if (Session["idxu"] != null && Session["idxu"].ToString().Length > 0)
                {
                    obj.banner.CreatedByID = int.Parse(Session["idxu"].ToString());
                }

                _repository.Add(obj.banner);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Banner/Edit/5

        public ActionResult Edit(int id)
        {
            _bannerModel.banner = _repository.getItem(id);
            _bannerModel.isDelete = _bannerModel.banner.Deleted.GetValueOrDefault(false);
            _bannerModel.isPublish = _bannerModel.banner.Published.GetValueOrDefault(false);
            _bannerModel.positionType = _bannerModel.banner.BannerTypeID.GetValueOrDefault();

            _bannerModel.PositionBannerType = _repoType.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.BannerTypeID.ToString(),
                    Text = x.BannerTypeTitle
                });
            return View(_bannerModel);
        }

        //
        // POST: /Banner/Edit/5

        [HttpPost]
        public ActionResult Edit(BannerModel obj)
        {
            try
            {
                obj.banner.Published = obj.isPublish;
                obj.banner.Deleted = obj.isDelete;
                _repository.Edit(obj.banner);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // POST: /Banner/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
