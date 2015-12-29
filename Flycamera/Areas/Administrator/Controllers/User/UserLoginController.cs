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

namespace Flycamera.Areas.Administrator.Controllers.User
{

    public class UserLoginController : Controller
    {
        readonly IRepositryCustomers<Fly_Customer> _repositoryUser = null;

        public UserLoginController()
        {
            _repositoryUser = new CustomerDAO();
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                if (User.IsInRole(RoleUser.ADMIN))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                return View();
            }
            //return View();
        }

        //
        // POST: /Administrator/UserLogin/Create

        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {
            bool flag = false;
            try
            {
                Fly_Customer objUser = _repositoryUser.SignIn(uname, pwd);
                flag = (objUser != null && objUser.IsAdmin.GetValueOrDefault(false));
                if (flag)
                {
                    FormsAuthentication.SetAuthCookie(uname, true);
                    Session["idxu"] = objUser.CustomerID;

                }
                else
                {
                    return View();
                }
                return Json(flag, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session["idxu"] = null;

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
