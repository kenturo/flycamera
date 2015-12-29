using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Accessory
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class AccessoryController : Controller
    {
        //view model 
        ProductVM _vm = null;

        // repository
        readonly IRepositryBase<Fly_Product> _repository = null;
        readonly IRepositryBase<Fly_Category> _repoCategories = null;
        readonly IRepositryBase<Fly_Manufacturer> _repoManufacturer = null;
        readonly IRepositryBase<Fly_Discount> _repoDiscount = null;
        readonly IRepositryBase<Fly_RelatedProduct> _repoRelatedProduct = null;
        readonly IRepositrySectionGallery<Fly_SectionGallery> _repoSectionGallery = null;


        public AccessoryController()
        {
            //view-model
            _vm = new ProductVM();

            //repository
            _repository = new ProductDAO();
            _repoCategories = new CategoryDAO();
            _repoManufacturer = new ManufacturerDAO();
            _repoDiscount = new DiscountDAO();
            _repoRelatedProduct = new RelatedProductDAO();
            _repoSectionGallery = new SectionGalleryDAO();
            
        }
        //
        // GET: /Administrator/Accessories/
        public ActionResult Index()
        {
            try
            {
                _vm.ProductList = _repository.getAllItems().Where(x => x.isAccessories.GetValueOrDefault(false) == true).ToList();
                return View(_vm);
            }
            catch (Exception exception)
            {
            }
            return View();
        }

        // GET: /Administrator/Accessories/create
        public ActionResult Create()
        {
            try
            {
                //get all categories of product
                _vm.CategoriesItemList = _repoCategories.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.CategoryID.ToString(),
                        Text = x.Name
                    });

                //get all manufacturer of product
                _vm.ManufacturerItemList = _repoManufacturer.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.ManufacturerID.ToString(),
                        Text = x.Name
                    });

                //get all Discount of product
                _vm.DiscountItemList = _repoDiscount.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.DiscountID.ToString(),
                        Text = x.Name
                    });

                return View(_vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ProductVM obj)
        {
            try
            {
                using (TransactionScope scpScope = new TransactionScope())
                {

                    //save product table
                    _vm.Product.Name = obj.Product.Name;
                    _vm.Product.ShortDescription = obj.Product.ShortDescription;
                    _vm.Product.FullDescription = obj.Product.FullDescription;
                    _vm.Product.CreatedOn = DateTime.Now;
                    _vm.Product.UpdatedOn = DateTime.Now;
                    _vm.Product.Published = obj.isPublish;
                    _vm.Product.Deleted = obj.isDelete;
                    _vm.Product.isAccessories = true;
                    _vm.Product.ShowOnHomePage = obj.isHome;

                    // save productvariant table
                    _vm.ProductVariant = obj.ProductVariant;
                    _vm.ProductVariant.CreatedOn = DateTime.Now;
                    _vm.ProductVariant.UpdatedOn = DateTime.Now;
                    _vm.ProductVariant.Deleted = _vm.Product.Deleted;
                    _vm.ProductVariant.Name = _vm.Product.Name;
                    _vm.ProductVariant.Description = _vm.Product.FullDescription;
                    _vm.ProductVariant.DisplayOrder = _vm.Product.ProductId;
                    _vm.ProductVariant.Published = _vm.Product.Published;
                    _vm.ProductVariant.IsShipEnabled = obj.isShipEnabled;
                    _vm.ProductVariant.IsFreeShipping = obj.isFreeShipping;
                    _vm.ProductVariant.CallForPrice = obj.isCallForPrice;
                    _vm.ProductVariant.isHot = obj.isHot;
                    _vm.ProductVariant.isNew = obj.isNew;
                    _vm.ProductVariant.isGift = obj.isGift;
                    if (obj.indexDiscount > 0)
                    {
                        _vm.ProductVariant.Fly_ProductVariant_Discount_Mapping.Add(new Fly_ProductVariant_Discount_Mapping
                        {
                            DiscountID = obj.indexDiscount,
                            Createdon = DateTime.Now
                        });
                    }
                    _vm.Product.Fly_ProductVariant.Add(_vm.ProductVariant);
                    _vm.Product.Fly_ProductLocalized.Add(obj.ProductLocalized);
                    _vm.Product.Fly_ProductPicture.Add(obj.ProductPictures);


                    if (obj.indexCate > 0)
                    {
                        _vm.Product.Fly_Product_Category_Mapping.Add(new Fly_Product_Category_Mapping
                        {
                            CategoryID = obj.indexCate

                        });
                    }

                    if (obj.indexManufacturer > 0)
                    {
                        _vm.Product.Fly_Product_Manufacturer_Mapping.Add(new Fly_Product_Manufacturer_Mapping
                        {
                            ManufacturerID = obj.indexManufacturer
                        });
                    }

                    _vm.SectionGalleries.PositionGalleryID = 5; // gallery
                    _vm.SectionGalleries.CollectionImage = obj.SectionGalleries.CollectionImage.Substring(0,
                        obj.SectionGalleries.CollectionImage.Length - 1);
                    _vm.SectionGalleries.CreatedOn = DateTime.Now;
                    _vm.Product.Fly_SectionGallery.Add(_vm.SectionGalleries);


                    /* save mapping table ProductVariant width table Discount */
                    _repository.Add(_vm.Product);

                    if (obj.Product != null && obj.Product.ProductId > 0)
                    {
                        if (obj.arrRelationProduct != null && obj.arrRelationProduct.Trim().Length > 0)
                        {
                            for (int i = 0; i < obj.arrRelationProduct.Split(',').Length; i++)
                            {
                                _repoRelatedProduct.Add(new Fly_RelatedProduct()
                                {
                                    ProductID1 = obj.Product.ProductId,
                                    ProductID2 = int.Parse(obj.arrRelationProduct.Split(',')[i])
                                });
                            }
                        }
                    }

                    scpScope.Complete();
                    scpScope.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }


        // GET: /Administrator/Accessories/Edit/id

        public ActionResult Edit(int id)
        {
            try
            {

                // get product table
                _vm.Product = _repository.getItem(id);

                _vm.SectionGalleries = _vm.Product.Fly_SectionGallery.FirstOrDefault();

                //set product entity
                _vm.Product.Published = _vm.Product.Published;
                _vm.Product.Deleted = _vm.Product.Deleted;
                _vm.Product.isAccessories = false;
                _vm.Product.ShowOnHomePage = _vm.Product.ShowOnHomePage;

                // set productvariant entity
                _vm.ProductVariant = _vm.Product.Fly_ProductVariant.FirstOrDefault();

                if (_vm.ProductVariant != null)
                {
                    _vm.ProductVariantLocalized = _vm.ProductVariant.Fly_ProductVariantLocalized.FirstOrDefault();

                    // set ProductLocalized & ProductPictures entity
                    _vm.ProductLocalized = _vm.Product.Fly_ProductLocalized.FirstOrDefault();
                    _vm.ProductPictures = _vm.Product.Fly_ProductPicture.FirstOrDefault();

                    // set index Cate
                    _vm.MappingCategories = _vm.Product.Fly_Product_Category_Mapping.FirstOrDefault();
                    _vm.indexCate = (_vm.MappingCategories != null) ? _vm.MappingCategories.CategoryID.GetValueOrDefault(0) : 0;

                    // set index Manufacturer
                    _vm.MappingManufacturer = _vm.Product.Fly_Product_Manufacturer_Mapping.FirstOrDefault();
                    _vm.indexManufacturer = (_vm.MappingManufacturer != null) ? _vm.MappingManufacturer.ManufacturerID.GetValueOrDefault(0) : 0;

                    // set index Discount 
                    _vm.MappingDiscount = _vm.ProductVariant.Fly_ProductVariant_Discount_Mapping.FirstOrDefault();
                }
                _vm.indexDiscount = (_vm.MappingDiscount != null) ? _vm.MappingDiscount.DiscountID : 0;


                //get all categories of product
                _vm.CategoriesItemList = _repoCategories.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.CategoryID.ToString(),
                        Text = x.Name
                    });

                //get all manufacturer of product
                _vm.ManufacturerItemList = _repoManufacturer.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.ManufacturerID.ToString(),
                        Text = x.Name
                    });

                //get all Discount of product
                _vm.DiscountItemList = _repoDiscount.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.DiscountID.ToString(),
                        Text = x.Name
                    });


                return View(_vm);
            }
            catch (Exception e)
            {
                return View(e.StackTrace);
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ProductVM obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    // get product table


                    //save product table
                    obj.Product.Published = obj.isPublish;
                    obj.Product.Deleted = obj.isDelete;
                    obj.Product.isAccessories = obj.isAccessories;
                    obj.Product.UpdatedOn = DateTime.Now;
                    obj.Product.ShowOnHomePage = obj.isHome;

                    // save productvariant table
                    obj.ProductVariant.IsShipEnabled = obj.isShipEnabled;
                    obj.ProductVariant.IsFreeShipping = obj.isFreeShipping;
                    obj.ProductVariant.UpdatedOn = DateTime.Now;
                    obj.ProductVariant.CallForPrice = obj.isCallForPrice;
                    obj.ProductVariant.Deleted = obj.Product.Deleted;
                    obj.ProductVariant.Name = obj.Product.Name;
                    obj.ProductVariant.Description = obj.Product.FullDescription;
                    obj.ProductVariant.Published = obj.Product.Published;
                    obj.ProductVariant.isHot = obj.isHot;
                    obj.ProductVariant.isNew = obj.isNew;
                    obj.ProductVariant.isGift = obj.isGift;

                    if (obj.indexDiscount > 0)
                    {
                        obj.ProductVariant.Fly_ProductVariant_Discount_Mapping.Add(new Fly_ProductVariant_Discount_Mapping
                        {
                            DiscountID = obj.indexDiscount,
                            DiscountMappingID = obj.MappingDiscount.DiscountMappingID,
                            ProductVariantID = obj.ProductVariant.ProductVariantId
                        });
                    }
                    obj.Product.Fly_ProductVariant.Add(obj.ProductVariant);
                    obj.Product.Fly_ProductLocalized.Add(obj.ProductLocalized);
                    obj.Product.Fly_ProductPicture.Add(obj.ProductPictures);

                    if (obj.indexCate > 0)
                    {
                        obj.Product.Fly_Product_Category_Mapping.Add(new Fly_Product_Category_Mapping
                        {
                            CategoryID = obj.indexCate,
                            ProductCategoryID = obj.MappingCategories.ProductCategoryID
                        });
                    }

                    if (obj.indexManufacturer > 0)
                    {
                        obj.Product.Fly_Product_Manufacturer_Mapping.Add(new Fly_Product_Manufacturer_Mapping
                        {
                            ManufacturerID = obj.indexManufacturer,
                            ProductManufacturerID = obj.MappingManufacturer.ProductManufacturerID
                        });
                    }

                    if (!obj.isNullData)
                    {
                        obj.SectionGalleries.PositionGalleryID = 5; // gallery
                        obj.SectionGalleries.CollectionImage = obj.SectionGalleries.CollectionImage.Substring(0,
                            obj.SectionGalleries.CollectionImage.Length - 1);
                        obj.SectionGalleries.CreatedOn = DateTime.Now;
                        obj.SectionGalleries.ProductID = obj.Product.ProductId;
                        _repoSectionGallery.Add(obj.SectionGalleries);
                    }

                    _repository.Edit(obj.Product);

                    if (obj.arrRelationProduct != null)
                    {
                        for (int i = 0; i < obj.arrRelationProduct.Split(',').Length; i++)
                        {
                            if (obj.arrRelationId != null && (obj.arrRelationId.Split(',')[i]) != null)
                            {
                                _repoRelatedProduct.Edit(new Fly_RelatedProduct()
                                {
                                    ProductID1 = obj.Product.ProductId,
                                    ProductID2 = int.Parse(obj.arrRelationProduct.Split(',')[i]),
                                    RelatedProductID = int.Parse(obj.arrRelationId.Split(',')[i])
                                });
                            }
                        }
                    }

                    scope.Complete();
                    scope.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        //
        // POST: /ProductAdmin/Delete/5
    }
}
