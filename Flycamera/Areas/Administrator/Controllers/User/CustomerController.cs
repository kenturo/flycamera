using System;
using System.Collections;
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
        readonly IRepositryCustomers<Fly_Customer> _repositoryUser = null;
        readonly IRepositryBase<Fly_CustomerRole> _repositoryUserRole = null;
        readonly IRepositryBase<Fly_Country> _repositoryCountry = null;
        readonly IRepositryMappingRole<Fly_Customer_CustomerRole_Mapping> _repositryMappingRole = null;


        readonly CustomerVM _vm = null;

        public CustomerController()
        {
            _repositoryUser = new CustomerDAO();
            _repositoryCountry = new CountryDAO();
            _repositoryUserRole = new CustomerRoleDAO();
            _repositryMappingRole = new CustomerMappingRoleDao();
            _vm = new CustomerVM();
        }


        //
        // GET: /Administrator/Customer/

        public ActionResult Index()
        {
            try
            {
                _vm.ListCustomer = _repositoryUser.getAllItems().ToList();
                return View(_vm);
            }
            catch (Exception ex)
            {
                return View(ex.InnerException.Message);
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
                _vm.Customer = _repositoryUser.getItem(id);
                if (_vm.Customer != null)
                {
                    _vm.CustomerAttr = _vm.Customer.Fly_CustomerAttribute.FirstOrDefault(x => x.CustomerId.Equals(id));
                    _vm.CustomerAvatar = _vm.Customer.Fly_Picture;
                    //vm.MappingRole = vm.Customer.Fly_Customer_CustomerRole_Mapping.Where(x => x.CustomerID.Equals(id)).FirstOrDefault();
                    _vm.ListCustomerRole = _repositoryUserRole.getAllItems().Where(x=>x.Active == true).ToList();

                    foreach (var valuemp in _vm.ListCustomerRole)
                    {
                        foreach (var cusmpRole in _vm.Customer.Fly_Customer_CustomerRole_Mapping)
                        {
                            if (valuemp.CustomerRoleID.Equals(cusmpRole.CustomerRoleID))
                            {
                                valuemp.Selected = true;
                            }
                        }
                    }
                    //vm.CustomerProductPrice = vm.CustomerRole.Fly_CustomerRole_ProductPrice.Where(x => x.CustomerRoleID.Equals(vm.CustomerRole.CustomerRoleID)).FirstOrDefault();
                    //vm.MappingDiscount = vm.CustomerRole.Fly_CustomerRole_Discount_Mapping.Where(x => x.CustomerRoleID.Equals(vm.CustomerRole.CustomerRoleID)).FirstOrDefault(); ;

                    _vm.isActive = _vm.Customer.Active.GetValueOrDefault();
                    _vm.isAdmin = _vm.Customer.IsAdmin.GetValueOrDefault();
                }
                if (_vm.CustomerAttr != null) _vm.selectItem = _vm.CustomerAttr.CountryID.GetValueOrDefault();

                if (_repositoryCountry != null)
                    _vm.PositionCountry = _repositoryCountry.getAllItems().Select(
                        x => new SelectListItem
                        {
                            Value = x.CountryID.ToString(),
                            Text = x.Name
                        });

                return View(_vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // POST: /Administrator/Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(CustomerVM obj,FormCollection collect, int id)
        {
            try
            {
                _vm.CustomerAttr = obj.CustomerAttr;
                _vm.CustomerAttr.CountryID = obj.selectItem;
                _vm.CustomerAttr.CustomerId = id;

                _vm.Customer = obj.Customer;
                _vm.Customer.IsAdmin = obj.isAdmin;
                _vm.Customer.Active = obj.isActive;


                if (string.IsNullOrWhiteSpace(_vm.CustomerAttr.FirstName))
                {
                    _vm.CustomerAttr.FirstName = "Unknow";
                }
                if (string.IsNullOrWhiteSpace(_vm.CustomerAttr.LastName))
                {
                    _vm.CustomerAttr.LastName = "Unknow";
                }
                if (string.IsNullOrWhiteSpace(_vm.CustomerAttr.City))
                {
                    _vm.CustomerAttr.City = "Unknow";
                }
                if (string.IsNullOrWhiteSpace(_vm.CustomerAttr.StreetAddress))
                {
                    _vm.CustomerAttr.StreetAddress = "Unknow";
                }
                _vm.Customer.Fly_CustomerAttribute.Add(_vm.CustomerAttr);

                if (collect.GetValue("f-ck") != null)
                {
                    foreach (var fckb in (IEnumerable) collect.GetValue("f-ck").RawValue)
                    {
                        _repositryMappingRole.Add(new Fly_Customer_CustomerRole_Mapping()
                        {
                            CustomerRoleID = int.Parse(fckb.ToString()),
                            CustomerID = id,
                            Creadedon = DateTime.Now
                        });
                    }
                }

                _vm.ListMappingRole = _repositryMappingRole.GetAllItemByCustomerId(id);
                
                _repositoryUser.Edit(_vm.Customer);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
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
            return Json(_repositoryUser.activeAdmin(id, isAdmin), JsonRequestBehavior.DenyGet);
        }
    }
}
