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
namespace Flycamera.Areas.Administrator.Controllers.Partnership
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class PartnershipController : Controller
    {
        IRepositryBase<Fly_Partnership> repository = null;
        PartnershipVM vm = null;

        public PartnershipController()
        {
            repository = new PartnershipDAO();
            vm = new PartnershipVM();
        }

        //
        // GET: /Partnership/

        public ActionResult Index()
        {
            try
            {

                IList<Fly_Partnership> flyv = repository.getAllItems();
                return View(flyv);

            }
            catch
            {

                return View();
            }
        }

        //
        // GET: /Partnership/Create

        public ActionResult Create()
        {
            return View(vm);
        }

        //
        // POST: /Partnership/Create

        [HttpPost]
        public ActionResult Create(PartnershipVM obj)
        {
            try
            {
                // save data
                obj.Partnership.Deleted = obj.isDelete;
                obj.Partnership.Published = obj.isPublish;
                obj.Partnership.CreatedOn = DateTime.Now;
                if (Session["idxu"] != null && Session["idxu"].ToString().Length > 0)
                {
                    obj.Partnership.CreatedByID = int.Parse(Session["idxu"].ToString());
                }
                repository.Add(obj.Partnership);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Partnership/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                //get one data
                vm.Partnership = repository.getItem(id);
                vm.isDelete = vm.Partnership.Deleted.GetValueOrDefault(false);
                vm.isPublish = vm.Partnership.Published.GetValueOrDefault(true);
                return View(vm);
            }
            catch
            {

                return View();
            }
        }

        //
        // POST: /Partnership/Edit/5

        [HttpPost]
        public ActionResult Edit(PartnershipVM obj)
        {
            try
            {
                // edit record
                obj.Partnership.Deleted = obj.isDelete;
                obj.Partnership.Published = obj.isPublish;
                repository.Edit(obj.Partnership);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Partnership/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                //delete record
                repository.Delete(id);
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
