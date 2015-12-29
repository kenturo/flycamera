using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Discount
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class DiscountController : Controller
    {
        private readonly IRepositryBase<Fly_Discount> _repositryBase = null;
        private DiscountVm _vm = null;

        public DiscountController()
        {
            this._repositryBase = new DiscountDAO();
            _vm = new DiscountVm();
        }

        //
        // GET: /Administrator/Discount/

        public ActionResult Index()
        {
            try
            {
                _vm.ListDiscount = _repositryBase.getAllItems().ToList();
                return View(_vm);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                _vm.FlyDiscount = _repositryBase.getItem(id);
                return View(_vm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(DiscountVm obj)
        {
            try
            {
                obj.FlyDiscount.Deleted = obj.Deleted;
                obj.FlyDiscount.EndDate = DateTime.Now;
                _repositryBase.Edit(obj.FlyDiscount);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public ActionResult Create()
        {
            return View(_vm);
        }

        [HttpPost]
        public ActionResult Create(DiscountVm obj)
        {
            try
            {
                obj.FlyDiscount.Deleted = obj.Deleted;
                obj.FlyDiscount.StartDate = DateTime.Now;
                obj.FlyDiscount.EndDate = DateTime.Now;
                _repositryBase.Add(obj.FlyDiscount);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
