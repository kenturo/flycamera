using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;
namespace Flycamera.Areas.Administrator.Controllers.ProductGallery
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class ProductGalleryController : Controller
    {
        ProductGalleryVM vm = null;
        readonly IRepositryPositionGallery<Fly_PositionGallery> _repoPosition = null;
        readonly IRepositrySectionGallery<Fly_SectionGallery> _repoSectionGallery = null;
        readonly IRepositrySectionContent<Fly_SectionContent> _repoSectionContent = null;
        private string _posTab;
        public ProductGalleryController()
        {
            vm = new ProductGalleryVM();
            _repoPosition = new PositionGalleryDAO();
            _repoSectionGallery = new SectionGalleryDAO();
            _repoSectionContent = new SectionContentDAO();
        }

       

        //
        // GET: /Administrator/ProductGallery/

        public ActionResult Index()
        {
            _posTab = this.RouteData.Values["catepage"].ToString().ToLower() == PositionTab.Overview.ToLower() ? PositionTab.Overview : PositionTab.Feature;
            vm.ListSectionContents =
                    _repoSectionContent.getAllItems()
                        .Where(x => x.Fly_PositionGallery.PositionName_EN.Equals(_posTab))
                        .ToList();
            vm.ListSectionGalleries =
                    _repoSectionGallery.getAllItems()
                        .Where(x => x.Fly_PositionGallery.PositionName_EN.Equals(_posTab))
                        .ToList();
                return View(vm);
        }

        //
        // GET: /Administrator/ProductGallery/Create

        public ActionResult Create()
        {
            try
            {
                return View(vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        
        // GET: /Administrator/ProductGallery/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                string viewsNode = "Edit";
                _posTab = this.RouteData.Values["catepage"].ToString().ToLower() == PositionTab.Overview.ToLower() ? PositionTab.Overview : PositionTab.Feature;
                vm.SectionContents = _repoSectionContent.GetItemByProductAndType(id,_posTab);
                vm.ListSectionGalleries.Add(_repoSectionGallery.GetItemByProductAndType(id, _posTab));
                vm.ListSectionGalleries.Add(_repoSectionGallery.GetItemByProductAndType(id, PositionTab.Gallery.ToLower()));
                viewsNode = _posTab == PositionTab.Overview ? "EditOverview" : "EditFeaturies";
                return View(viewsNode, vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // POST: /Administrator/ProductGallery/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProductGalleryVM obj, string typePage)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    obj.SectionGalleries.PositionGalleryID = _repoPosition.GetItemByPosName(typePage).PositionGalleryID;
                    obj.SectionGalleries.CollectionImage = obj.SectionGalleries.CollectionImage.Substring(0,
                        obj.SectionGalleries.CollectionImage.Length - 1);
                    obj.SectionContents.PositionGalleryID = obj.SectionGalleries.PositionGalleryID;
                    obj.SectionContents.UpdateOn = DateTime.Now;


                    _repoSectionContent.Edit(obj.SectionContents);

//                    if (typePage == PositionTab.Overview)
//                    {
                        obj.ListSectionGalleries.Add(obj.SectionGalleries);
                        if (obj.CollectUrlGallery != null && obj.CollectUrlGallery.Any())
                        {
                            obj.ListSectionGalleries.Add(new Fly_SectionGallery()
                            {
                                CollectionImage = obj.CollectUrlGallery.Substring(0,
                                    obj.CollectUrlGallery.Length - 1),
                                CreatedOn = DateTime.Now,
                                PositionGalleryID = _repoPosition.GetItemByPosName(PositionTab.Gallery).PositionGalleryID,
                                ProductID = obj.SectionContents.ProductID
                            });
                            foreach (var listSectionGallery in obj.ListSectionGalleries)
                            {
                                _repoSectionGallery.Edit(listSectionGallery);
                            }
                        }
//                    }
//                    else
//                    {
//                        _repoSectionGallery.Edit(obj.SectionGalleries);
//                    }


                    scope.Complete();
                    scope.Dispose();
                }

                string routeDirect = typePage == PositionTab.Overview ? "/Administrator/ProductGallery/overview" : "/Administrator/ProductGallery/featuries";

                return Redirect(routeDirect);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

      

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        [HttpGet]
        public void Delete(string id)
        {
            var filename = id;
            var filePath = Path.Combine(Server.MapPath("~/Content/Upload/"), filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        //
        // POST: /Administrator/ProductGallery/Delete/5

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




        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Overview(ProductGalleryVM obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    // TODO: Add insert logic here
                    obj = ExcuteActionCommonView(obj);
                    obj.SectionGalleries.PositionGalleryID = _repoPosition.GetItemByPosName(PositionTab.Overview).PositionGalleryID;
                    obj.SectionContents.PositionGalleryID = obj.SectionGalleries.PositionGalleryID;
                    obj.ListSectionGalleries.Add(obj.SectionGalleries);

                    if (obj.CollectUrlGallery != null && obj.CollectUrlGallery.Any())
                    {
                        obj.ListSectionGalleries.Add(new Fly_SectionGallery()
                        {
                            CollectionImage = obj.CollectUrlGallery.Substring(0,
                            obj.CollectUrlGallery.Length - 1),
                            CreatedOn = DateTime.Now,
                            PositionGalleryID = _repoPosition.GetItemByPosName(PositionTab.Gallery).PositionGalleryID,
                            ProductID = obj.SectionContents.ProductID
                        });
                    }
                   
                    
                    _repoSectionContent.Add(obj.SectionContents);
                    foreach (var listSectionGallery in obj.ListSectionGalleries)
                    {
                        _repoSectionGallery.Add(listSectionGallery);
                    }

                    scope.Complete();
                    scope.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Featuries(ProductGalleryVM obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    // TODO: Add insert logic here
                    obj = ExcuteActionCommonView(obj);
                    obj.SectionGalleries.PositionGalleryID = _repoPosition.GetItemByPosName(PositionTab.Feature).PositionGalleryID;
                    obj.SectionContents.PositionGalleryID = obj.SectionGalleries.PositionGalleryID;

                    _repoSectionContent.Add(obj.SectionContents);
                    _repoSectionGallery.Add(obj.SectionGalleries);

                    scope.Complete();
                    scope.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        ProductGalleryVM ExcuteActionCommonView(ProductGalleryVM obj)
        {
            obj.SectionGalleries.CollectionImage = obj.SectionGalleries.CollectionImage.Substring(0,
                        obj.SectionGalleries.CollectionImage.Length - 1);
            obj.SectionGalleries.CreatedOn = DateTime.Now;
            obj.SectionContents.CreatedOn = DateTime.Now;
            obj.SectionContents.UpdateOn = DateTime.Now;

            return obj;
        }
    }
}
