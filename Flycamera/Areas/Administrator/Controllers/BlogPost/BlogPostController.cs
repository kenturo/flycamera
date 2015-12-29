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

namespace Flycamera.Areas.Administrator.Controllers.BlogPost
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class BlogPostController : Controller
    {
        readonly BlogPostVm _vm = null;
        readonly IRepositryBase<Fly_BlogPost> _repos = null;
        readonly IRepositryBase<Fly_BlogPostType> _reposType = null;

        public BlogPostController()
        {
            _repos = new BlogPostDAO();
            _reposType = new BlogPostTypeDAO();
            _vm = new BlogPostVm();
        }

        //
        // GET: /Administrator/BlogPost/

        public ActionResult Index()
        {
            _vm.ListBlogPost = _repos.getAllItems().ToList();
            return View(_vm);
        }

        
        //
        // GET: /Administrator/BlogPost/Create

        public ActionResult Create()
        {
            _vm.PosBlogTypeList = _reposType.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.BlogPostTypeID.ToString(),
                    Text = x.Title
                });
            return View(_vm);
        }

        //
        // POST: /Administrator/BlogPost/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BlogPostVm obj)
        {
            try
            {
                // TODO: Add insert logic here
                obj.Blogpost.BlogPostTypeID = 1;
                obj.Blogpost.Published = obj.IsPublish;
                obj.Blogpost.CreatedOn = DateTime.Now;
                obj.Blogpost.Tags = "";


                if (Session["idxu"] != null && Session["idxu"].ToString().Length > 0)
                {
                    obj.Blogpost.CreatedByID = int.Parse(Session["idxu"].ToString());
                }

                _repos.Add(obj.Blogpost);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // GET: /Administrator/BlogPost/Edit/5

        public ActionResult Edit(int id)
        {
            _vm.Blogpost = _repos.getItem(id);
            _vm.IsVideo = _vm.Blogpost.BlogPostTypeID.GetValueOrDefault(0);
            _vm.IsPublish = _vm.Blogpost.Published.GetValueOrDefault(true);
            _vm.BlogpostType = _reposType.getItem(_vm.IsVideo);
            return View(_vm);
        }

        //
        // POST: /Administrator/BlogPost/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, BlogPostVm obj)
        {
            try
            {
                // TODO: Add update logic here
                if (obj.IsVideo == 1)
                {
                    obj.Blogpost.VideoLink = "";
                }
                obj.Blogpost.Published = obj.IsPublish;
                obj.Blogpost.CreatedOn = DateTime.Now;
                _repos.Edit(obj.Blogpost);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Administrator/BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repos.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administrator/BlogPost/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
