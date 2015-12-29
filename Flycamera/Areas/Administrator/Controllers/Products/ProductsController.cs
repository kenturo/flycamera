using System;
using System.Collections.Generic;
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

namespace Flycamera.Areas.Administrator.Controllers.Products
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class ProductsController : Controller
    {
        //view model 
        ProductVM vm = null;

        // repository
        readonly IRepositryBase<Fly_Product> repository = null;
        readonly IRepositryBase<Fly_Category> _repoCategories = null;
        readonly IRepositryBase<Fly_Manufacturer> _repoManufacturer = null;
        readonly IRepositryBase<Fly_Discount> _repoDiscount = null;
        readonly IRepositryBase<Fly_RelatedProduct> _repoRelatedProduct = null;
     
        public ProductsController()
        {
            //view-model
            vm = new ProductVM();

            //repository
            repository = new ProductDAO();
            _repoCategories = new CategoryDAO();
            _repoManufacturer = new ManufacturerDAO();
            _repoDiscount = new DiscountDAO();
            _repoRelatedProduct = new RelatedProductDAO();

            
        }

        //
        // GET: /ProductAdmin/

        public ActionResult Index()
        {
            try
            {

                vm.ProductList = repository.getAllItems().Where(x=>x.isAccessories.GetValueOrDefault(false) == false).ToList();
                return View(vm);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        //
        // GET: /ProductAdmin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ProductAdmin/Create

        public ActionResult Create()
        {
            try
            {
                //get all categories of product
                vm.CategoriesItemList = _repoCategories.getAllItems().ToList().Where(c=>c.Deleted == false).Select(
                    x => new SelectListItem { 
                        Value = x.CategoryID.ToString(), 
                        Text = x.Name 
                    });

                //get all manufacturer of product
                vm.ManufacturerItemList = _repoManufacturer.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem { 
                        Value = x.ManufacturerID.ToString(), 
                        Text = x.Name 
                    });

                //get all Discount of product
                vm.DiscountItemList = _repoDiscount.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.DiscountID.ToString(),
                        Text = x.Name
                    });

                return View(vm);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // POST: /ProductAdmin/Create

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ProductVM obj)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    //save product table
                    obj.Product.Published = obj.isPublish;
                    obj.Product.Deleted = obj.isDelete;
                    obj.Product.isAccessories = false;
                    obj.Product.ShowOnHomePage = obj.isHome;
                    obj.Product.CreatedOn = DateTime.Now;
                    obj.Product.UpdatedOn = DateTime.Now;

                    // save productvariant table
                    obj.ProductVariant.IsShipEnabled = obj.isShipEnabled;
                    obj.ProductVariant.IsFreeShipping = obj.isFreeShipping;
                    obj.ProductVariant.CallForPrice = obj.isCallForPrice;
                    obj.ProductVariant.CreatedOn = DateTime.Now;
                    obj.ProductVariant.UpdatedOn = DateTime.Now;
                    obj.ProductVariant.Deleted = obj.Product.Deleted;
                    obj.ProductVariant.Name = obj.Product.Name;
                    obj.ProductVariant.Published = obj.Product.Published;
                    obj.ProductVariant.Description = obj.Product.FullDescription;
                    obj.ProductVariant.isHot = obj.isHot;
                    obj.ProductVariant.isNew = obj.isNew;
                    obj.ProductVariant.isGift = obj.isGift;

                    if (obj.indexDiscount > 0)
                    {
                        obj.ProductVariant.Fly_ProductVariant_Discount_Mapping.Add(new Fly_ProductVariant_Discount_Mapping
                        {
                            DiscountID = obj.indexDiscount,
                            Createdon = DateTime.Now
                        });
                    }
                    obj.Product.Fly_ProductVariant.Add(obj.ProductVariant);


                    obj.Product.Fly_ProductLocalized.Add(obj.ProductLocalized);
                    obj.Product.Fly_ProductPicture.Add(obj.ProductPictures);

                    if (obj.indexCate > 0)
                    {
                        obj.Product.Fly_Product_Category_Mapping.Add(new Fly_Product_Category_Mapping
                        {
                            CategoryID = obj.indexCate
                        });
                    }

                    if (obj.indexManufacturer > 0)
                    {
                        obj.Product.Fly_Product_Manufacturer_Mapping.Add(new Fly_Product_Manufacturer_Mapping
                        {
                            ManufacturerID = obj.indexManufacturer
                        });
                    }


                    /* save mapping table ProductVariant width table Discount */
                    repository.Add(obj.Product);



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

        //
        // GET: /ProductAdmin/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {

                // get product table
                vm.Product = repository.getItem(id);

                //set product entity
                vm.Product.Published = vm.Product.Published;
                vm.Product.Deleted = vm.Product.Deleted;
                vm.Product.isAccessories = false;
                vm.Product.ShowOnHomePage = vm.Product.ShowOnHomePage;

                // set productvariant entity
                vm.ProductVariant = vm.Product.Fly_ProductVariant.FirstOrDefault();

                if (vm.ProductVariant != null)
                {
                    vm.ProductVariantLocalized = vm.ProductVariant.Fly_ProductVariantLocalized.FirstOrDefault();

                    // set ProductLocalized & ProductPictures entity
                    vm.ProductLocalized = vm.Product.Fly_ProductLocalized.FirstOrDefault();
                    vm.ProductPictures = vm.Product.Fly_ProductPicture.FirstOrDefault();

                    // set index Cate
                    vm.MappingCategories = vm.Product.Fly_Product_Category_Mapping.FirstOrDefault();
                    vm.indexCate = (vm.MappingCategories != null) ? vm.MappingCategories.CategoryID.GetValueOrDefault(0) : 0;

                    // set index Manufacturer
                    vm.MappingManufacturer = vm.Product.Fly_Product_Manufacturer_Mapping.FirstOrDefault();
                    vm.indexManufacturer = (vm.MappingManufacturer != null) ? vm.MappingManufacturer.ManufacturerID.GetValueOrDefault(0) : 0;

                    // set index Discount 
                    vm.MappingDiscount = vm.ProductVariant.Fly_ProductVariant_Discount_Mapping.FirstOrDefault();
                }
                vm.indexDiscount = (vm.MappingDiscount != null) ? vm.MappingDiscount.DiscountID : 0;


                //get all categories of product
                vm.CategoriesItemList = _repoCategories.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.CategoryID.ToString(),
                        Text = x.Name
                    });

                //get all manufacturer of product
                vm.ManufacturerItemList = _repoManufacturer.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.ManufacturerID.ToString(),
                        Text = x.Name
                    });

                //get all Discount of product
                vm.DiscountItemList = _repoDiscount.getAllItems().ToList().Where(c => c.Deleted == false).Select(
                    x => new SelectListItem
                    {
                        Value = x.DiscountID.ToString(),
                        Text = x.Name
                    });

                return View(vm);
            }
            catch (Exception e)
            {
                return View(e.StackTrace);
            }
        }

        //
        // POST: /ProductAdmin/Edit/5

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
                    obj.Product.ShowOnHomePage = obj.isHome;

                    // save productvariant table
                    obj.ProductVariant.IsShipEnabled = obj.isShipEnabled;
                    obj.ProductVariant.IsFreeShipping = obj.isFreeShipping;
                    obj.ProductVariant.CallForPrice = obj.isCallForPrice;
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


                    repository.Edit(obj.Product);

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
                return View(e.Message);
            }
        }

        //
        // POST: /ProductAdmin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // save product table
                //vm.Product.Deleted = true;
                //repository.Edit(vm.Product);

                //// save productvariant table
                //vm.ProductVariant.ProductID = id;
                //vm.ProductVariant.Deleted = true;
                //_repoVariant.Edit(vm.ProductVariant);

                return View();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

    }
}
