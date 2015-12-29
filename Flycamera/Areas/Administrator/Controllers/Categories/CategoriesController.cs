using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity.DataAccess;
using FlyEntity;
using Flycamera.ViewModel;
using FlyEntity.Repositry;
using Flycamera.Areas.Administrator.ViewModel;
using Flycamera.App_Start;
using FlyEntity.Utilities;



namespace Flycamera.Areas.Administrator.Controllers.Categories
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class CategoriesController : Controller
    {

        IRepositryBase<Fly_Category> repository = null;
        IRepositryBase<Fly_Discount> repositoryD = null;

        // view model
        CategoriesVM vm = new CategoriesVM();

        public CategoriesController()
        {
            repository = new CategoryDAO();
            repositoryD = new DiscountDAO();
        }


        //
        // GET: /Categories/

        public ActionResult Index()
        {
            try
            {

                vm.ListCategories = repository.getAllItems().ToList();
                return View(vm);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            vm.SelectItemDiscount = repositoryD.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.DiscountID.ToString(),
                    Text = x.Name
                });

            return View(vm);
        }

        //
        // POST: /Categories/Create
        [HttpPost]
        public ActionResult Create(CategoriesVM obj)
        {
            try
            {
                // save record Categories
                obj.Categories.Published = obj.isPublish;
                obj.Categories.Deleted = obj.isDelete;
                obj.Categories.ShowOnHomePage = obj.isHome;
                obj.Categories.CreatedOn = DateTime.Now;
                //save record CategoriesLocalized
                obj.Categories.Fly_CategoryLocalized.Add(obj.CategoriesLocalized);


                //save record Categories Mapping Discount
                obj.CategoryDiscountMapping.DiscountID = obj.SelectValues;
                obj.CategoryDiscountMapping.Createdon = DateTime.Now;
                obj.Categories.Fly_Category_Discount_Mapping.Add(obj.CategoryDiscountMapping);

                // save
                repository.Add(obj.Categories);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id)
        {
            // get Categories
            vm.Categories = repository.getItem(id);
            vm.isDelete = vm.Categories.Deleted.GetValueOrDefault(true);
            vm.isPublish = vm.Categories.Published.GetValueOrDefault(false);
            vm.isHome = vm.Categories.ShowOnHomePage.GetValueOrDefault(true);
            // get CategoryDiscountMapping
            vm.CategoryDiscountMapping = vm.Categories.Fly_Category_Discount_Mapping.FirstOrDefault();
            vm.SelectValues = (vm.CategoryDiscountMapping != null) ? vm.CategoryDiscountMapping.DiscountID : 0;
            vm.CategoriesLocalized = vm.Categories.Fly_CategoryLocalized.FirstOrDefault();

            vm.SelectItemDiscount = repositoryD.getAllItems().Select(
               x => new SelectListItem
               {
                   Value = x.DiscountID.ToString(),
                   Text = x.Name
               });
            return View(vm);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(CategoriesVM obj)
        {
            try
            {
                //// save record Categories
                //obj.Categories.Published = obj.isPublish;
                //obj.Categories.Deleted = obj.isDelete;
                //obj.Categories.ShowOnHomePage = obj.isHome;
                //repository.Edit(obj.Categories);

                ////save record CategoriesLocalized
                //obj.CategoriesLocalized.CategoryID = obj.Categories.CategoryID;
                //repositoryLocalized.Edit(obj.CategoriesLocalized);

                ////save record Categories Mapping Discount
                //obj.CategoryDiscountMapping.CategoryID = obj.Categories.CategoryID;
                //obj.CategoryDiscountMapping.DiscountID = obj.SelectValues;
                //repositoryMapping.Edit(obj.CategoryDiscountMapping);


                /**/
                // save record Categories
                obj.Categories.Published = obj.isPublish;
                obj.Categories.Deleted = obj.isDelete;
                obj.Categories.UpdatedOn = DateTime.Now;
                obj.Categories.ShowOnHomePage = obj.isHome;

                //save record CategoriesLocalized
                obj.Categories.Fly_CategoryLocalized.Add(obj.CategoriesLocalized);


                //save record Categories Mapping Discount
                obj.CategoryDiscountMapping.DiscountID = obj.SelectValues;
                obj.Categories.Fly_Category_Discount_Mapping.Add(obj.CategoryDiscountMapping);

                // save
                repository.Edit(obj.Categories);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // POST: /Categories/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                //delete record
                repository.Delete(id);
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
