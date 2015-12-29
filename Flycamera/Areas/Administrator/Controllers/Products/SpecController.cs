using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Products
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class SpecController : Controller
    {
        ProductGalleryVM vm = null;
        readonly IRepositrySectionContent<Fly_SectionContent> _repository = null;
        readonly IRepositryBase<Fly_PositionGallery> _repoPositionPos = null;



        public SpecController()
        {
            vm = new ProductGalleryVM();
            _repository = new SectionContentDAO();
            _repoPositionPos = new PositionGalleryDAO();
        }

        //
        // GET: /Administrator/Spec/

        public ActionResult Index()
        {
            vm.ListSectionContents = _repository.getAllItemsByPosition(PositionTab.Specs).ToList();
            return View(vm);
        }

        //
        // GET: /Administrator/Spec/Create

        public ActionResult Create()
        {
            vm.PositionGalleries = _repoPositionPos.getAllItems().FirstOrDefault(x => x.PositionName.Equals(PositionTab.Specs));
            return View(vm);
        }

        //
        // POST: /Administrator/Spec/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductGalleryVM obj)
        {
            try
            {
                // TODO: Add insert logic here
                obj.SectionContents.CreatedOn = DateTime.Now;
                obj.SectionContents.UpdateOn = DateTime.Now;
                obj.SectionContents.PositionGalleryID = obj.PositionGalleries.PositionGalleryID;
                _repository.Add(obj.SectionContents);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Administrator/Spec/Edit/5

        public ActionResult Edit(int id)
        {
            vm.SectionContents = _repository.getItemsByPosition(PositionTab.Specs);
            return View(vm);
        }

        //
        // POST: /Administrator/Spec/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, ProductGalleryVM obj)
        {
            try
            {
                obj.SectionContents.UpdateOn = DateTime.Now;
                _repository.Edit(obj.SectionContents);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Administrator/Spec/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Spec/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, ProductGalleryVM obj)
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
