using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;
using System.Web.Mvc;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;


namespace Flycamera.Areas.Administrator.ViewModel
{
    public class ProductVM
    {
     
        

        /* attribute */
        public Fly_Product Product { get; set; }
        public Fly_ProductLocalized ProductLocalized { get; set; }
        public Fly_ProductVariant ProductVariant { get; set; }
        public Fly_ProductVariantLocalized ProductVariantLocalized { get; set; }
        public Fly_Category Categories { get; set; }
        public Fly_Manufacturer Manufacturers { get; set; }
        public Fly_RelatedProduct RelateProducts { get; set; }
        public Fly_ProductPicture ProductPictures { get; set; }
        public Fly_Product_Category_Mapping MappingCategories { get; set; }
        public Fly_Product_Manufacturer_Mapping MappingManufacturer { get; set; }
        public Fly_ProductVariant_Discount_Mapping MappingDiscount { get; set; }
        public Fly_SectionGallery SectionGalleries { get; set; }


        //list-object
        public List<Fly_Product> ProductList { get; set; }
        public List<Fly_ProductLocalized> ProductLocalizedList { get; set; }
        public List<Fly_ProductVariant> ProductVariantList { get; set; }
        public List<Fly_ProductVariantLocalized> ProductVariantLocalizedList { get; set; }
        public List<Fly_Category> CategoryList { get; set; }
        public List<Fly_Manufacturer> ManufacturerList { get; set; }
        public List<Fly_RelatedProduct> RelatedProductList { get; set; }
        public List<Fly_ProductPicture> ProductPictureList { get; set; }
        public List<Fly_Product_Category_Mapping> MappingCategoriesList { get; set; }
        public List<Fly_Product_Manufacturer_Mapping> MappingManufacturerList { get; set; }
        public List<Fly_ProductVariant_Discount_Mapping> MappingDiscountList { get; set; }
        public List<Fly_SectionGallery> ListSectionGalleries;


        public int indexCate { get; set; }
        public int indexManufacturer { get; set; }
        public int indexDiscount { get; set; }
        public bool isHome { get; set; }
        public bool isDelete { get; set; }
        public bool isPublish { get; set; }
        public bool isShipEnabled { get; set; }
        public bool isFreeShipping { get; set; }
        public bool isCallForPrice { get; set; }
        public bool isHot { get; set; }
        public bool isNew { get; set; }
        public bool isGift { get; set; }
        public bool isAccessories { get; set; }
        public bool isNullData { get; set; }
        public string arrRelationProduct { get; set; }
        public string arrRelationId { get; set; }

        // SelectItem
        public IEnumerable<SelectListItem> CategoriesItemList { get; set; }
        public IEnumerable<SelectListItem> ManufacturerItemList { get; set; }
        public IEnumerable<SelectListItem> DiscountItemList { get; set; }


        public ProductVM()
        {
            // attribute
            Product = new Fly_Product();
            ProductLocalized = new Fly_ProductLocalized();
            ProductVariant = new Fly_ProductVariant();
            ProductVariantLocalized = new Fly_ProductVariantLocalized();
            Categories = new Fly_Category();
            Manufacturers = new Fly_Manufacturer();
            RelateProducts = new Fly_RelatedProduct();
            ProductPictures = new Fly_ProductPicture();
            MappingCategories = new Fly_Product_Category_Mapping();
            MappingManufacturer = new Fly_Product_Manufacturer_Mapping();
            MappingDiscount = new Fly_ProductVariant_Discount_Mapping();
            SectionGalleries = new Fly_SectionGallery();

            // ListObject
            ProductList = new List<Fly_Product>();
            ProductLocalizedList = new List<Fly_ProductLocalized>();
            ProductVariantList =new List<Fly_ProductVariant>();
            ProductVariantLocalizedList =new List<Fly_ProductVariantLocalized>();
            CategoryList =new List<Fly_Category>();
            ManufacturerList =new List<Fly_Manufacturer>();
            RelatedProductList =new List<Fly_RelatedProduct>();
            ProductPictureList =new List<Fly_ProductPicture>();
            MappingCategoriesList = new List<Fly_Product_Category_Mapping>();
            MappingManufacturerList =new List<Fly_Product_Manufacturer_Mapping>();
            MappingDiscountList =new List<Fly_ProductVariant_Discount_Mapping>();

            // attribute bool
            isHome = true;
            isDelete = false;
            isPublish = true;
            isShipEnabled = true;
            isFreeShipping = false;
            isCallForPrice = false;
            isHot = false;
            isNew = true;
            isGift = false;
            isNullData = false;
            isAccessories = false;

            //// Select Item
            //CategoriesItemList = new IEnumerable<SelectListItem>();
            //ManufacturerItemList = new IEnumerable<SelectListItem>();
            //DiscountItemList = new IEnumerable<SelectListItem>();
        }

    }
}