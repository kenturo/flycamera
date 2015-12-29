using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;

namespace Flycamera.Areas.Administrator.Controllers.Navigation
{
    public class NavigationController : Controller
    {
        private readonly IRepositryBase<Fly_Navigation> _repositryBase = null;
        private NavigationVm _vm = null;


        public NavigationController()
        {
            _repositryBase = new NavigationDao();
            _vm = new NavigationVm();
        }

        //
        // GET: /Administrator/Navigation/

        public ActionResult Index()
        {
            return View(_repositryBase.getAllItems());
        }


        public ActionResult Edit(int id)
        {
            try
            {
                _vm.Navigation = _repositryBase.getItem(id);
                _vm.SubProducts = _vm.Navigation.title_en;
                _vm.Publish = _vm.Navigation.Published.GetValueOrDefault();
                _vm.Deleted = _vm.Navigation.Deleted.GetValueOrDefault();

                return View(_vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(NavigationVm obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _vm.Navigation = obj.Navigation;
                    _vm.Navigation.Published = obj.Publish;
                    _vm.Navigation.Deleted = obj.Deleted;
                    _vm.Navigation.CreatedOn = DateTime.Now;
                    if (obj.SubProducts != null && obj.SubProducts.Any())
                    {
                        _vm.Navigation.parentid = 3;
                    }
                    _repositryBase.Edit(_vm.Navigation);

                    scope.Complete();
                    scope.Dispose();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public ActionResult Create()
        {
            return View(_vm);
        }

        [HttpPost]
        public ActionResult Create(NavigationVm obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _vm.Navigation = obj.Navigation;
                    _vm.Navigation.Published = obj.Publish;
                    _vm.Navigation.Deleted = obj.Deleted;
                    _vm.Navigation.CreatedOn = DateTime.Now;
                    if (obj.SubProducts != null && obj.SubProducts.Any())
                    {
                        _vm.Navigation.parentid = 3;
                    }
                    _repositryBase.Add(_vm.Navigation);

                    scope.Complete();
                    scope.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
            
        }

    }
}
