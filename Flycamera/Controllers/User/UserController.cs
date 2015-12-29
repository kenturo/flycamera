using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Flycamera.App_Start;
using Flycamera.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;
namespace Flycamera.Controllers.User
{
    public class UserController : BaseController
    {
        readonly IRepositryBase<Fly_Country> _country = null;
        readonly IRepositryCustomers<Fly_Customer> _repositoryUser = null;
        UserVM vm = null;

        public UserController()
        {
            _country = new CountryDAO();
            _repositoryUser = new CustomerDAO();
            vm = new UserVM();
        }


        //
        // GET: /User/Create

        public ActionResult Register()
        {
            vm.CountryList = _country.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.CountryID.ToString(),
                    Text = x.Name.ToString()
                });
            return View(vm);
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Register(UserVM obj)
        {
            try
            {
                obj.CustomerAttribute.CountryID = 229;// id country vietname
                if (string.IsNullOrWhiteSpace(obj.CustomerAttribute.FirstName))
                {
                    obj.CustomerAttribute.FirstName = "Unknow";
                }
                if (string.IsNullOrWhiteSpace(obj.CustomerAttribute.LastName))
                {
                    obj.CustomerAttribute.LastName = "Unknow";
                }
                if (string.IsNullOrWhiteSpace(obj.CustomerAttribute.City))
                {
                    obj.CustomerAttribute.City = "Unknow";
                }
                if (string.IsNullOrWhiteSpace(obj.CustomerAttribute.StreetAddress))
                {
                    obj.CustomerAttribute.StreetAddress = "Unknow";
                }

                obj.Customer.Fly_CustomerAttribute.Add(obj.CustomerAttribute);
                obj.Customer.CustomerGUID = Guid.NewGuid();
                _repositoryUser.Add(obj.Customer);
                return RedirectToActionPermanent("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Login(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {
            try
            {
                Fly_Customer objUser = _repositoryUser.SignIn(uname,pwd);
//                string role = (objUser.IsAdmin.GetValueOrDefault(false)) ? true : false;
                var flag = (objUser != null);
                if (flag)
                {
                    FormsAuthentication.SetAuthCookie(uname, true);
                    Session["idxu"] = objUser.CustomerID;
                    Session.Timeout = 60;
                }
                return Json(flag, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session["idxu"] = null;

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public CaptchaImage ShowCaptchaImage()
        {
            return new CaptchaImage();
        }
    }
}
