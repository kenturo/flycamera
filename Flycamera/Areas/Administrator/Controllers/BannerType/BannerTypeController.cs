using FlyEntity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.Repositry;
using Flycamera.App_Start;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.BannerType
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class BannerTypeController : Controller
    {
        IRepositryBase<Fly_BannerType> repository = null;


        public BannerTypeController()
        {
            repository = new BannerTypeDAO();
        }

        //
        // GET: /BannerType/

        public ActionResult Index()
        {
            try
            {

                IList<Fly_BannerType> lbn = repository.getAllItems();
                return View(lbn);
            }
            catch
            {

                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                var _item = repository.getItem(id);
                return View(_item);
            }
            catch
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Fly_BannerType bannertype)
        {
            try
            {
                repository.Edit(bannertype);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }


        //
        // GET: /abc/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /abc/Create

        [HttpPost]
        public ActionResult Create(FlyEntity.Fly_BannerType bannertype)
        {
            try
            {
                // TODO: Add insert logic here
                repository.Add(bannertype);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /abc/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

    }
}
