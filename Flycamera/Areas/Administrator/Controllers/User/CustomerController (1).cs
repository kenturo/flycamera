using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;

namespace Flycamera.Areas.Administrator.Controllers.User
{
    public class CustomerController : Controller
    {
        IRepositryCustomers<Fly_Customer> repositoryUser = null;
        IRepositryBase<Fly_CustomerRole> repositoryUserRole = null;
        IRepositryBase<Fly_Country> repositoryCountry = null;
        CustomerVM vm = null;

        public CustomerController()
        {
            repositoryUser = new CustomerDAO();
            repositoryCountry = new CountryDAO();
            repositoryUserRole = new CustomerRoleDAO();
            vm = new CustomerVM();
        }


        //
        // GET: /Administrator/Customer/

        public ActionResult Index()
        {
            try
            {
                vm.ListCustomer = repositoryUser.getAllItems().ToList();
                return View(vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // GET: /Administrator/Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administrator/Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Customer/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administrator/Customer/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                vm.Customer = repositoryUser.getItem(id);
                vm.CustomerAttr = vm.Customer.Fly_CustomerAttribute.Single(x => x.CustomerId.Equals(id));
                vm.CustomerAvatar = vm.Customer.Fly_Picture;
                //vm.MappingRole = vm.Customer.Fly_Customer_CustomerRole_Mapping.Where(x => x.CustomerID.Equals(id)).FirstOrDefault();
                vm.ListCustomerRole = repositoryUserRole.getAllItems().Where(x=>x.Active == true).ToList();
                //vm.CustomerProductPrice = vm.CustomerRole.Fly_CustomerRole_ProductPrice.Where(x => x.CustomerRoleID.Equals(vm.CustomerRole.CustomerRoleID)).FirstOrDefault();
                //vm.MappingDiscount = vm.CustomerRole.Fly_CustomerRole_Discount_Mapping.Where(x => x.CustomerRoleID.Equals(vm.CustomerRole.CustomerRoleID)).FirstOrDefault(); ;

                vm.isActive = vm.Customer.Active.GetValueOrDefault();
                vm.isAdmin = vm.Customer.IsAdmin.GetValueOrDefault();
                vm.selectItem = vm.CustomerAttr.CountryID.GetValueOrDefault();

                vm.PositionCountry = repositoryCountry.getAllItems().Select(
                   x => new SelectListItem
                   {
                       Value = x.CountryID.ToString(),
                       Text = x.Name
                   });

                return View(vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // POST: /Administrator/Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administrator/Customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Administrator/Customer/Delete/5

        [HttpPost]
        public ActionResult activeAdministrator(int id, bool isAdmin)
        {
            return Json(repositoryUser.activeAdmin(id, isAdmin), JsonRequestBehavior.DenyGet);
        }
    }
}
