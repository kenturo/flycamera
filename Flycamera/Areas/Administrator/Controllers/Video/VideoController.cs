using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.Repositry;
using FlyEntity.DataAccess;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Video
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class VideoController : Controller
    {
        readonly IRepositryVideos<Fly_Videos> _repository = null;
        readonly IRepositryPositionGallery<Fly_PositionGallery> _repositoryPos = null;

        readonly VideoVM _vm = null;
        //VideosDAO repository = new VideosDAO();
        //PositionGalleryDAO posGallery = new PositionGalleryDAO();
        //SectionContentDAO secContentDAO = new SectionContentDAO();

        public VideoController()
        {
            _vm = new VideoVM();
            _repository = new VideosDAO();
            _repositoryPos = new PositionGalleryDAO();
        }

        //
        // GET: /Video/

        public ActionResult Index()
        {
            _vm.ListVideo = _repository.getAllItems().ToList();
            return View(_vm);
        }

        //
        // GET: /Video/Details/5

        public ActionResult Create()
        {
            _vm.PositionGalleriesItemList = _repositoryPos.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.PositionGalleryID.ToString(),
                    Text = x.PositionName
                });
            _vm.Video = new Fly_Videos
            {
                Published = true,
                Deleted = false,
                isShowHome = false
            };
            return View(_vm);
        }

        //
        // POST: /Video/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(VideoVM obj, int id = 0)
        {
            try
            {
                    // save table SectionContent
                    obj.SectionContents.PositionGalleryID = obj.positionVideo;

                    // save table video
                    obj.Video.PositionID = obj.positionVideo;
                    obj.Video.Published = obj.isPublish;
                    obj.Video.Deleted = obj.isDeleted;
                    obj.Video.isShowHome = obj.isHome;
                    obj.Video.Fly_SectionContent = obj.SectionContents;

                    if (Session["idxu"] != null && Session["idxu"].ToString().Length > 0)
                    {
                        obj.Video.CreatedByID = int.Parse(Session["idxu"].ToString());
                    }
                    _repository.Add(obj.Video);

                    return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Video/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                _vm.Video = _repository.getItem(id);
                _vm.isDeleted = _vm.Video.Deleted.GetValueOrDefault(true);
                _vm.isPublish = _vm.Video.Published.GetValueOrDefault(true);
                _vm.isHome = _vm.Video.isShowHome.GetValueOrDefault(true);
                _vm.positionVideo = _vm.Video.PositionID.GetValueOrDefault();


                _vm.PositionGalleriesItemList = _repositoryPos.getAllItems().Select(
                    x => new SelectListItem
                    {
                        Value = x.PositionGalleryID.ToString(),
                        Text = x.PositionName
                    });
                return View(_vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // POST: /Video/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(VideoVM obj,int id)
        {
            try
            {
                // save table SectionContent
                //obj.Video.Fly_SectionContent.PositionGalleryID = obj.positionVideo;

                // get id new record save
                //obj.Video.SectionContentID = secContentDAO.AddItem(vm.SectionContents);

                // save table video
                obj.Video.PositionID = obj.positionVideo;
                obj.Video.Published = obj.isPublish;
                obj.Video.Deleted = obj.isDeleted;
                obj.Video.isShowHome = obj.isHome;

                obj.Video.Fly_SectionContent.SectionContentID = obj.Video.SectionContentID.GetValueOrDefault();
                obj.Video.Fly_SectionContent.PositionGalleryID = obj.positionVideo;
                obj.Video.Fly_SectionContent.ProductID = obj.Video.ProductId;

                _repository.Edit(obj.Video);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // POST: /Video/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.Delete(id);
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TabVideo()
        {
            try
            {
                _vm.PositionGalleriesItemList = _repositoryPos.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.PositionGalleryID.ToString(),
                    Text = x.PositionName
                });
                _vm.Video = new Fly_Videos();
                _vm.Video.Published = true;
                _vm.Video.Deleted = false;
                _vm.Video.isShowHome = false;
                return View(_vm);
            }
            catch (Exception e)
            {

                return View(e.Message);
            }
        }

        public ActionResult EventClip()
        {
            _vm.ListVideo = _repository.getAllItems().Where(x=>x.Fly_PositionGallery.PositionName_EN.Equals(PositionTab.EventClip)).ToList();
            return View(_vm);
        }

        public ActionResult CreateEventClip()
        {
            try
            {
                _vm.Video = new Fly_Videos
                {
                    Published = true,
                    Deleted = false,
                    isShowHome = false
                };
            }
            catch (Exception e)
            {
                
                throw e.InnerException;
            }
            return View(_vm);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateEventClip(VideoVM obj, int id = 0)
        {

            try
            {
                // save table SectionContent
                obj.SectionContents.PositionGalleryID =
                    _repositoryPos.GetItemByPosName(PositionTab.EventClip).PositionGalleryID;

                // save table video
                obj.Video.PositionID = obj.SectionContents.PositionGalleryID;
                obj.Video.Published = obj.isPublish;
                obj.Video.Deleted = obj.isDeleted;
                obj.Video.CreatedOn =DateTime.Now;
                obj.Video.isShowHome = obj.isHome;
                obj.Video.Fly_SectionContent = obj.SectionContents;

                if (Session["idxu"] != null && Session["idxu"].ToString().Length > 0)
                {
                    obj.Video.CreatedByID = int.Parse(Session["idxu"].ToString());
                }
                _repository.Add(obj.Video);

                return RedirectToAction("EventClip");
            }
            catch (Exception e)
            {
                return View(e.InnerException.Message);
            }
        }


        public ActionResult EditEventClip(int id)
        {
            try
            {
                _vm.Video = _repository.getItem(id);
                _vm.isDeleted = _vm.Video.Deleted.GetValueOrDefault(true);
                _vm.isPublish = _vm.Video.Published.GetValueOrDefault(true);
                _vm.isHome = _vm.Video.isShowHome.GetValueOrDefault(true);
                _vm.positionVideo = _vm.Video.PositionID.GetValueOrDefault();
                return View(_vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // POST: /Video/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditEventClip(VideoVM obj, int id)
        {
            try
            {
                // save table SectionContent
                //obj.Video.Fly_SectionContent.PositionGalleryID = obj.positionVideo;

                // get id new record save
                //obj.Video.SectionContentID = secContentDAO.AddItem(vm.SectionContents);

                // save table video
                obj.Video.PositionID = obj.positionVideo;
                obj.Video.Published = obj.isPublish;
                obj.Video.Deleted = obj.isDeleted;
                obj.Video.isShowHome = obj.isHome;

                obj.Video.Fly_SectionContent.SectionContentID = obj.Video.SectionContentID.GetValueOrDefault();
                obj.Video.Fly_SectionContent.PositionGalleryID = obj.positionVideo;
                obj.Video.Fly_SectionContent.ProductID = obj.Video.ProductId;

                _repository.Edit(obj.Video);
                return RedirectToAction("EventClip");
            }
            catch (Exception e)
            {
                return View(e.InnerException.Message);
            }
        }

        //
        // POST: /Video/Delete/5



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult TabVideo(VideoVM obj, int id = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // save table SectionContent
                    obj.SectionContents.PositionGalleryID = obj.positionVideo;

                    // get id new record save
                    //obj.Video.SectionContentID = secContentDAO.AddItem(vm.SectionContents);

                    // save table video
                    obj.Video.PositionID = obj.positionVideo;
                    obj.Video.Published = obj.isPublish;
                    obj.Video.Deleted = obj.isDeleted;
                    obj.Video.isShowHome = obj.isHome;
                    obj.Video.Fly_SectionContent = obj.SectionContents;
                    _repository.Add(obj.Video);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}
