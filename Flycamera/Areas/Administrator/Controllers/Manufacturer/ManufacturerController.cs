using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.DataAccess;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity.Repositry;
using Flycamera.App_Start;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Manufacturer
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class ManufacturerController : Controller
    {
        IRepositryBase<Fly_Manufacturer> repository = null;
        IRepositryBase<Fly_ManufacturerLocalized> repositoryLocalized = null;

        ManufacturerVM vm = new ManufacturerVM();

        public ManufacturerController()
        {
            repository = new ManufacturerDAO();
            repositoryLocalized = new ManufacturerLocalizedDAO();
        }

        //
        // GET: /Manufacturer/

        public ActionResult Index()
        {
            try
            {

                // get all data
                vm.ListManufacturer = repository.getAllItems().ToList();
                return View(vm);
            }
            catch
            {

                return View();
            }
        }

        //
        // GET: /Manufacturer/Create

        public ActionResult Create()
        {
            return View(vm);
        }

        //
        // POST: /Manufacturer/Create

        [HttpPost]
        public ActionResult Create(ManufacturerVM obj)
        {
            try
            {
                // save Manufacturer
                obj.Manufacturer.Published = obj.isPubish;
                obj.Manufacturer.Deleted = obj.isDelete;
                obj.Manufacturer.CreatedOn = DateTime.Now;

                // save ManufacturerLocalized
                obj.ManufacturerLocalized.ManufacturerID = obj.Manufacturer.ManufacturerID;
                obj.Manufacturer.Fly_ManufacturerLocalized.Add(obj.ManufacturerLocalized);

                repository.Add(obj.Manufacturer);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Manufacturer/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                vm.Manufacturer = repository.getItem(id);
                vm.isPubish = vm.Manufacturer.Published.GetValueOrDefault(true) ;
                vm.isDelete = vm.Manufacturer.Deleted.GetValueOrDefault(false);
                vm.ManufacturerLocalized = vm.Manufacturer.Fly_ManufacturerLocalized.FirstOrDefault();
                return View(vm);
            }
            catch
            {

                return View();
            }
        }

        //
        // POST: /Manufacturer/Edit/5

        [HttpPost]
        public ActionResult Edit(ManufacturerVM obj)
        {
            try
            {
                // save Manufacturer
                obj.Manufacturer.Published = obj.isPubish;
                obj.Manufacturer.Deleted = obj.isDelete;
                obj.Manufacturer.UpdatedOn = DateTime.Now;

                // save ManufacturerLocalized
                obj.ManufacturerLocalized.ManufacturerID = obj.Manufacturer.ManufacturerID;
                obj.Manufacturer.Fly_ManufacturerLocalized.Add(obj.ManufacturerLocalized);

                repository.Edit(obj.Manufacturer);


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // POST: /Manufacturer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                //delete Manufacturer
                repository.Delete(id);
                return View();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}
