using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using System.Web.Mvc;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class CategoriesVM
    {
        public Fly_Category Categories { get; set; }
        public Fly_CategoryLocalized CategoriesLocalized { get; set; }
        public Fly_Discount Discount { get; set; }
        public Fly_Category_Discount_Mapping CategoryDiscountMapping { get; set; }

        public bool isPublish { get; set; }
        public bool isDelete { get; set; }
        public bool isHome { get; set; }
        public int SelectValues { get; set; }

        public List<Fly_Category> ListCategories { get; set; }
        public List<Fly_CategoryLocalized> ListCategoriesLocalized { get; set; }
        public List<Fly_Discount> ListDiscount { get; set; }
        public List<Fly_Category_Discount_Mapping> ListCategoryDiscountMapping { get; set; }

        public IEnumerable<SelectListItem> SelectItemDiscount { get; set; }


        public CategoriesVM() 
        {
            Categories = new Fly_Category();
            CategoriesLocalized = new Fly_CategoryLocalized();
            Discount = new Fly_Discount();
            CategoryDiscountMapping = new Fly_Category_Discount_Mapping();

            isPublish = true;
            isDelete = false;
            isHome = false;

            ListCategories = new List<Fly_Category>();
            ListCategoriesLocalized = new List<Fly_CategoryLocalized>();
            ListDiscount = new List<Fly_Discount>();
            ListCategoryDiscountMapping = new List<Fly_Category_Discount_Mapping>();
            SelectItemDiscount = new List<SelectListItem>();
        }
    }
}