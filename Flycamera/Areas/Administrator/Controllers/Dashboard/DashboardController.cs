﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Dashboard
{
    [Authorize(Roles=RoleUser.ADMIN)]
    public class DashboardController : Controller
    {

        //protected override void EndExecute(IAsyncResult asyncResult)
        //{
        //    if (CookiesData.isExistSessionAdmin(this.Session, "membership"))
        //    {
        //        HttpContext.Response.Redirect("/administrator/userlogin/login");
        //        //this.RedirectToAction("login", "userlogin");
        //    }
        //    base.EndExecute(asyncResult);
        //}
        //
        // GET: /Administrator/Dashboard/

        public ActionResult Index()
        {
            return View();
        }



        //
        // GET: /Administrator/Dashboard/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administrator/Dashboard/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Dashboard/Create

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
        // GET: /Administrator/Dashboard/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Dashboard/Edit/5

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
        // GET: /Administrator/Dashboard/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Dashboard/Delete/5

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
    }
}
