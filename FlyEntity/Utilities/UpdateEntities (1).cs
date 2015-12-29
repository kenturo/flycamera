using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Utilities
{
    public static class UpdateEntities
    {
        public static Fly_Product_Category_Mapping UpdateEntity(Fly_Product_Category_Mapping ItemNew, Fly_Product_Category_Mapping ItemOld)
        {
            Fly_Product_Category_Mapping rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.CategoryID = (ItemNew.CategoryID == null || ItemNew.CategoryID.Equals(ItemOld.CategoryID)) ? ItemOld.CategoryID : ItemNew.CategoryID;
                rs.DisplayOrder = (ItemNew.DisplayOrder == null || ItemNew.DisplayOrder.Equals(ItemOld.DisplayOrder)) ? ItemOld.DisplayOrder : ItemNew.DisplayOrder;
                rs.IsFeaturedProduct = (ItemNew.IsFeaturedProduct == null || ItemNew.IsFeaturedProduct.Equals(ItemOld.IsFeaturedProduct)) ? ItemOld.IsFeaturedProduct : ItemNew.IsFeaturedProduct;
                rs.ProductID = (ItemNew.ProductID == null || ItemNew.ProductID.Equals(ItemOld.ProductID)) ? ItemOld.ProductID : ItemNew.ProductID;
            }
            return rs;
        }

        public static Fly_Product_Manufacturer_Mapping UpdateEntity(Fly_Product_Manufacturer_Mapping ItemNew, Fly_Product_Manufacturer_Mapping ItemOld)
        {
            Fly_Product_Manufacturer_Mapping rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.ManufacturerID = (ItemNew.ManufacturerID == null || ItemNew.ManufacturerID.Equals(ItemOld.ManufacturerID)) ? ItemOld.ManufacturerID : ItemNew.ManufacturerID;
                rs.DisplayOrder = (ItemNew.DisplayOrder == null || ItemNew.DisplayOrder.Equals(ItemOld.DisplayOrder)) ? ItemOld.DisplayOrder : ItemNew.DisplayOrder;
                rs.IsFeaturedProduct = (ItemNew.IsFeaturedProduct == null || ItemNew.IsFeaturedProduct.Equals(ItemOld.IsFeaturedProduct)) ? ItemOld.IsFeaturedProduct : ItemNew.IsFeaturedProduct;
                rs.ProductID = (ItemNew.ProductID == null || ItemNew.ProductID.Equals(ItemOld.ProductID)) ? ItemOld.ProductID : ItemNew.ProductID;
            }
            return rs;
        }

        public static Fly_ProductLocalized UpdateEntity(Fly_ProductLocalized ItemNew, Fly_ProductLocalized ItemOld)
        {
            Fly_ProductLocalized rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.LanguageID = (ItemNew.LanguageID == null || ItemNew.LanguageID.Equals(ItemOld.LanguageID)) ? ItemOld.LanguageID : ItemNew.LanguageID;
                rs.Name = (ItemNew.Name == null || ItemNew.Name.Equals(ItemOld.Name)) ? ItemOld.Name : ItemNew.Name;
                rs.ShortDescription = (ItemNew.ShortDescription == null || ItemNew.ShortDescription.Equals(ItemOld.ShortDescription)) ? ItemOld.ShortDescription : ItemNew.ShortDescription;
                rs.ProductID = (ItemNew.ProductID == null || ItemNew.ProductID.Equals(ItemOld.ProductID)) ? ItemOld.ProductID : ItemNew.ProductID;
            }
            return rs;
        }

        public static Fly_ProductPicture UpdateEntity(Fly_ProductPicture ItemNew, Fly_ProductPicture ItemOld)
        {
            Fly_ProductPicture rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.DisplayOrder = (ItemNew.DisplayOrder == null || ItemNew.DisplayOrder.Equals(ItemOld.DisplayOrder)) ? ItemOld.DisplayOrder : ItemNew.DisplayOrder;
                rs.PictureID = (ItemNew.PictureID == null || ItemNew.PictureID.Equals(ItemOld.PictureID)) ? ItemOld.PictureID : ItemNew.PictureID;
                rs.ProductID = (ItemNew.ProductID == null || ItemNew.ProductID.Equals(ItemOld.ProductID)) ? ItemOld.ProductID : ItemNew.ProductID;
            }
            return rs;
        }

        public static Fly_ProductVariant UpdateEntity(Fly_ProductVariant ItemNew, Fly_ProductVariant ItemOld)
        {
            Fly_ProductVariant rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.AdditionalShippingCharge = (ItemNew.AdditionalShippingCharge == null || ItemNew.AdditionalShippingCharge.Equals(ItemOld.AdditionalShippingCharge)) ? ItemOld.AdditionalShippingCharge : ItemNew.AdditionalShippingCharge;
                rs.AdminPrice = (ItemNew.AdminPrice == null || ItemNew.AdminPrice.Equals(ItemOld.AdminPrice)) ? ItemOld.AdminPrice : ItemNew.AdminPrice;
                rs.ProductID = (ItemNew.ProductID == null || ItemNew.ProductID.Equals(ItemOld.ProductID)) ? ItemOld.ProductID : ItemNew.ProductID;
                rs.Backorders = (ItemNew.Backorders == null || ItemNew.Backorders.Equals(ItemOld.Backorders)) ? ItemOld.Backorders : ItemNew.Backorders;
                rs.CallForPrice = (ItemNew.CallForPrice == null || ItemNew.CallForPrice.Equals(ItemOld.CallForPrice)) ? ItemOld.CallForPrice : ItemNew.CallForPrice;
                rs.CreatedOn = (ItemNew.CreatedOn == null || ItemNew.CreatedOn.Equals(ItemOld.CreatedOn)) ? ItemOld.CreatedOn : DateTime.Now;
                rs.Deleted = (ItemNew.Deleted == null || ItemNew.Deleted.Equals(ItemOld.Deleted)) ? ItemOld.Deleted : ItemNew.Deleted;
                rs.Description = (ItemNew.Description == null || ItemNew.Description.Equals(ItemOld.Description)) ? ItemOld.Description : ItemNew.Description;
                rs.DisableBuyButton = (ItemNew.DisableBuyButton == null || ItemNew.DisableBuyButton.Equals(ItemOld.DisableBuyButton)) ? ItemOld.DisableBuyButton : ItemNew.DisableBuyButton;
                rs.Height = (ItemNew.Height == null || ItemNew.Height.Equals(ItemOld.Height)) ? ItemOld.Height : ItemNew.Height;
                rs.DisplayOrder = (ItemNew.DisplayOrder == null || ItemNew.DisplayOrder.Equals(ItemOld.DisplayOrder)) ? ItemOld.DisplayOrder : ItemNew.DisplayOrder;
                rs.IsFreeShipping = (ItemNew.IsFreeShipping == null || ItemNew.IsFreeShipping.Equals(ItemOld.IsFreeShipping)) ? ItemOld.IsFreeShipping : ItemNew.IsFreeShipping;
                rs.isGift = (ItemNew.isGift == null || ItemNew.isGift.Equals(ItemOld.isGift)) ? ItemOld.isGift : ItemNew.isGift;
                rs.isHot = (ItemNew.isHot == null || ItemNew.isHot.Equals(ItemOld.isHot)) ? ItemOld.isHot : ItemNew.isHot;
                rs.isNew = (ItemNew.isNew == null || ItemNew.isNew.Equals(ItemOld.isNew)) ? ItemOld.isNew : ItemNew.isNew;
                rs.IsShipEnabled = (ItemNew.IsShipEnabled == null || ItemNew.IsShipEnabled.Equals(ItemOld.IsShipEnabled)) ? ItemOld.IsShipEnabled : ItemNew.IsShipEnabled;
                rs.IsTaxExempt = (ItemNew.IsTaxExempt == null || ItemNew.IsTaxExempt.Equals(ItemOld.IsTaxExempt)) ? ItemOld.IsTaxExempt : ItemNew.IsTaxExempt;
                rs.Length = (ItemNew.Length == null || ItemNew.Length.Equals(ItemOld.Length)) ? ItemOld.Length : ItemNew.Length;
                rs.ManageInventory = (ItemNew.ManageInventory == null || ItemNew.ManageInventory.Equals(ItemOld.ManageInventory)) ? ItemOld.ManageInventory : ItemNew.ManageInventory;
                rs.ManufacturerPartNumber = (ItemNew.ManufacturerPartNumber == null || ItemNew.ManufacturerPartNumber.Equals(ItemOld.ManufacturerPartNumber)) ? ItemOld.ManufacturerPartNumber : ItemNew.ManufacturerPartNumber;
                rs.Name = (ItemNew.Name == null || ItemNew.Name.Equals(ItemOld.Name)) ? ItemOld.Name : ItemNew.Name;
                rs.NotifyAdminForQuantityBelow = (ItemNew.NotifyAdminForQuantityBelow == null || ItemNew.NotifyAdminForQuantityBelow.Equals(ItemOld.NotifyAdminForQuantityBelow)) ? ItemOld.NotifyAdminForQuantityBelow : ItemNew.NotifyAdminForQuantityBelow;
                rs.OldPrice = (ItemNew.OldPrice == null || ItemNew.OldPrice.Equals(ItemOld.OldPrice)) ? ItemOld.OldPrice : ItemNew.OldPrice;
                rs.OrderMaximumQuantity = (ItemNew.OrderMaximumQuantity == null || ItemNew.OrderMaximumQuantity.Equals(ItemOld.OrderMaximumQuantity)) ? ItemOld.OrderMaximumQuantity : ItemNew.OrderMaximumQuantity;
                rs.OrderMinimumQuantity = (ItemNew.OrderMinimumQuantity == null || ItemNew.OrderMinimumQuantity.Equals(ItemOld.OrderMinimumQuantity)) ? ItemOld.OrderMinimumQuantity : ItemNew.OrderMaximumQuantity;
                rs.Price = (ItemNew.Price == null || ItemNew.Price.Equals(ItemOld.Price)) ? ItemOld.Price : ItemNew.Price;
                rs.ProductCost = (ItemNew.ProductCost == null || ItemNew.ProductCost.Equals(ItemOld.ProductCost)) ? ItemOld.ProductCost : ItemNew.ProductCost;
                rs.ProductID = (ItemNew.ProductID == null || ItemNew.ProductID.Equals(ItemOld.ProductID)) ? ItemOld.ProductID : ItemNew.ProductID;
                rs.Published = (ItemNew.Published == null || ItemNew.Published.Equals(ItemOld.Published)) ? ItemOld.Published : ItemNew.Published;
                rs.SKU = (ItemNew.SKU == null || ItemNew.SKU.Equals(ItemOld.SKU)) ? ItemOld.SKU : ItemNew.SKU;
                rs.UpdatedOn = (ItemNew.UpdatedOn == null || ItemNew.UpdatedOn.Equals(ItemOld.UpdatedOn)) ? ItemOld.UpdatedOn : DateTime.Now;
                rs.WarehouseID = (ItemNew.WarehouseID == null || ItemNew.WarehouseID.Equals(ItemOld.WarehouseID)) ? ItemOld.WarehouseID : ItemNew.WarehouseID;
                rs.Weight = (ItemNew.Weight == null || ItemNew.Weight.Equals(ItemOld.Weight)) ? ItemOld.Weight : ItemNew.Weight;
                rs.Width = (ItemNew.Width == null || ItemNew.Width.Equals(ItemOld.Width)) ? ItemOld.Width : ItemNew.Width;

            }
            return rs;
        }

        public static Fly_ProductVariant_Discount_Mapping UpdateEntity(Fly_ProductVariant_Discount_Mapping ItemNew, Fly_ProductVariant_Discount_Mapping ItemOld)
        {
            Fly_ProductVariant_Discount_Mapping rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.Createdon = (ItemNew.Createdon == null || ItemNew.Createdon.Equals(ItemOld.Createdon)) ? ItemOld.Createdon : DateTime.Now;
                rs.DiscountID = (ItemNew.DiscountID == null || ItemNew.DiscountID.Equals(ItemOld.DiscountID)) ? ItemOld.DiscountID : ItemNew.DiscountID;
                rs.ProductVariantID = (ItemNew.ProductVariantID == null || ItemNew.ProductVariantID.Equals(ItemOld.ProductVariantID)) ? ItemOld.ProductVariantID : ItemNew.ProductVariantID;
            }
            return rs;
        }

        public static Fly_ProductVariantLocalized UpdateEntity(Fly_ProductVariantLocalized ItemNew, Fly_ProductVariantLocalized ItemOld)
        {
            Fly_ProductVariantLocalized rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.LanguageID = (ItemNew.LanguageID == null || ItemNew.LanguageID.Equals(ItemOld.LanguageID)) ? ItemOld.LanguageID : ItemNew.LanguageID;
                rs.Name = (ItemNew.Name == null || ItemNew.Name.Equals(ItemOld.Name)) ? ItemOld.Name : ItemNew.Name;
                rs.Description = (ItemNew.Description == null || ItemNew.Description.Equals(ItemOld.Description)) ? ItemOld.Description : ItemNew.Description;
                rs.ProductVariantID = (ItemNew.ProductVariantID == null || ItemNew.ProductVariantID.Equals(ItemOld.ProductVariantID)) ? ItemOld.ProductVariantID : ItemNew.ProductVariantID;
            }
            return rs;
        }
        
        public static Fly_Product UpdateEntity(Fly_Product ItemNew, Fly_Product ItemOld)
        {
            Fly_Product rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.CreatedOn = (ItemNew.CreatedOn == null || ItemNew.CreatedOn.Equals(ItemOld.CreatedOn)) ? ItemOld.CreatedOn : DateTime.Now;
                rs.Name = (ItemNew.Name == null || ItemNew.Name.Equals(ItemOld.Name)) ? ItemOld.Name : ItemNew.Name;
                rs.Deleted = (ItemNew.Deleted == null || ItemNew.Deleted.Equals(ItemOld.Deleted)) ? ItemOld.Deleted : ItemNew.Deleted;
                rs.FullDescription = (ItemNew.FullDescription == null || ItemNew.FullDescription.Equals(ItemOld.FullDescription)) ? ItemOld.FullDescription : ItemNew.FullDescription;
                rs.Published = (ItemNew.Published == null || ItemNew.Published.Equals(ItemOld.Published)) ? ItemOld.Published : ItemNew.Published;
                rs.ShortDescription = (ItemNew.ShortDescription == null || ItemNew.ShortDescription.Equals(ItemOld.ShortDescription)) ? ItemOld.ShortDescription : ItemNew.ShortDescription;
                rs.ShowOnHomePage = (ItemNew.ShowOnHomePage == null || ItemNew.ShowOnHomePage.Equals(ItemOld.ShowOnHomePage)) ? ItemOld.ShowOnHomePage : ItemNew.ShowOnHomePage;
                rs.TemplateID = (ItemNew.TemplateID == null || ItemNew.TemplateID.Equals(ItemOld.TemplateID)) ? ItemOld.TemplateID : ItemNew.TemplateID;
                rs.UpdatedOn = (ItemNew.UpdatedOn == null || ItemNew.UpdatedOn.Equals(ItemOld.UpdatedOn)) ? ItemOld.UpdatedOn : DateTime.Now;
            }
            return rs;
        }

        public static Fly_RelatedProduct UpdateEntity(Fly_RelatedProduct ItemNew, Fly_RelatedProduct ItemOld)
        {
            Fly_RelatedProduct rs = ItemOld;
            if (ItemNew != null && ItemOld != null)
            {
                rs.ProductID1 = (ItemNew.ProductID1 == null || ItemNew.ProductID1.Equals(ItemOld.ProductID1)) ? ItemOld.ProductID1 : ItemNew.ProductID1;
                rs.ProductID2 = (ItemNew.ProductID2 == null || ItemNew.ProductID2.Equals(ItemOld.ProductID2)) ? ItemOld.ProductID2 : ItemNew.ProductID2;
                rs.RelatedProductID = (ItemNew.RelatedProductID == null || ItemNew.RelatedProductID.Equals(ItemOld.RelatedProductID)) ? ItemOld.RelatedProductID : ItemNew.RelatedProductID;
            }
            return rs;
        }
    }
}
