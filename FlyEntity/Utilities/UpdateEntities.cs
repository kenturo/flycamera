using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Utilities
{
    public static class UpdateEntities
    {
        public static Fly_Product_Category_Mapping UpdateEntity(Fly_Product_Category_Mapping itemNew, Fly_Product_Category_Mapping itemOld)
        {
            Fly_Product_Category_Mapping rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CategoryID = (itemNew.CategoryID == null || itemNew.CategoryID.Equals(itemOld.CategoryID)) ? itemOld.CategoryID : itemNew.CategoryID;
                rs.DisplayOrder = (itemNew.DisplayOrder == null || itemNew.DisplayOrder.Equals(itemOld.DisplayOrder)) ? itemOld.DisplayOrder : itemNew.DisplayOrder;
                rs.IsFeaturedProduct = (itemNew.IsFeaturedProduct == null || itemNew.IsFeaturedProduct.Equals(itemOld.IsFeaturedProduct)) ? itemOld.IsFeaturedProduct : itemNew.IsFeaturedProduct;
                rs.ProductID = (itemNew.ProductID == null || itemNew.ProductID.Equals(itemOld.ProductID)) ? itemOld.ProductID : itemNew.ProductID;
            }
            return rs;
        }

        public static Fly_Product_Manufacturer_Mapping UpdateEntity(Fly_Product_Manufacturer_Mapping itemNew, Fly_Product_Manufacturer_Mapping itemOld)
        {
            Fly_Product_Manufacturer_Mapping rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.ManufacturerID = (itemNew.ManufacturerID == null || itemNew.ManufacturerID.Equals(itemOld.ManufacturerID)) ? itemOld.ManufacturerID : itemNew.ManufacturerID;
                rs.DisplayOrder = (itemNew.DisplayOrder == null || itemNew.DisplayOrder.Equals(itemOld.DisplayOrder)) ? itemOld.DisplayOrder : itemNew.DisplayOrder;
                rs.IsFeaturedProduct = (itemNew.IsFeaturedProduct == null || itemNew.IsFeaturedProduct.Equals(itemOld.IsFeaturedProduct)) ? itemOld.IsFeaturedProduct : itemNew.IsFeaturedProduct;
                rs.ProductID = (itemNew.ProductID == null || itemNew.ProductID.Equals(itemOld.ProductID)) ? itemOld.ProductID : itemNew.ProductID;
            }
            return rs;
        }

        public static Fly_ProductLocalized UpdateEntity(Fly_ProductLocalized itemNew, Fly_ProductLocalized itemOld)
        {
            Fly_ProductLocalized rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.LanguageID = (itemNew.LanguageID == null || itemNew.LanguageID.Equals(itemOld.LanguageID)) ? itemOld.LanguageID : itemNew.LanguageID;
                rs.Name = (itemNew.Name == null || itemNew.Name.Equals(itemOld.Name)) ? itemOld.Name : itemNew.Name;
                rs.ShortDescription = (itemNew.ShortDescription == null || itemNew.ShortDescription.Equals(itemOld.ShortDescription)) ? itemOld.ShortDescription : itemNew.ShortDescription;
                rs.ProductID = (itemNew.ProductID == null || itemNew.ProductID.Equals(itemOld.ProductID)) ? itemOld.ProductID : itemNew.ProductID;
            }
            return rs;
        }

        public static Fly_ProductPicture UpdateEntity(Fly_ProductPicture itemNew, Fly_ProductPicture itemOld)
        {
            Fly_ProductPicture rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.DisplayOrder = (itemNew.DisplayOrder == null || itemNew.DisplayOrder.Equals(itemOld.DisplayOrder)) ? itemOld.DisplayOrder : itemNew.DisplayOrder;
                rs.PictureID = (itemNew.PictureID == null || itemNew.PictureID.Equals(itemOld.PictureID)) ? itemOld.PictureID : itemNew.PictureID;
                rs.ProductID = (itemNew.ProductID == null || itemNew.ProductID.Equals(itemOld.ProductID)) ? itemOld.ProductID : itemNew.ProductID;
            }
            return rs;
        }

        public static Fly_ProductVariant UpdateEntity(Fly_ProductVariant itemNew, Fly_ProductVariant itemOld)
        {
            Fly_ProductVariant rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.AdditionalShippingCharge = (itemNew.AdditionalShippingCharge == null || itemNew.AdditionalShippingCharge.Equals(itemOld.AdditionalShippingCharge)) ? itemOld.AdditionalShippingCharge : itemNew.AdditionalShippingCharge;
                rs.AdminPrice = (itemNew.AdminPrice == null || itemNew.AdminPrice.Equals(itemOld.AdminPrice)) ? itemOld.AdminPrice : itemNew.AdminPrice;
                rs.ProductID = (itemNew.ProductID == null || itemNew.ProductID.Equals(itemOld.ProductID)) ? itemOld.ProductID : itemNew.ProductID;
                rs.Backorders = (itemNew.Backorders == null || itemNew.Backorders.Equals(itemOld.Backorders)) ? itemOld.Backorders : itemNew.Backorders;
                rs.CallForPrice = (itemNew.CallForPrice == null || itemNew.CallForPrice.Equals(itemOld.CallForPrice)) ? itemOld.CallForPrice : itemNew.CallForPrice;
                rs.CreatedOn = (itemNew.CreatedOn == null || itemNew.CreatedOn.Equals(itemOld.CreatedOn)) ? itemOld.CreatedOn : DateTime.Now;
                rs.Deleted = (itemNew.Deleted == null || itemNew.Deleted.Equals(itemOld.Deleted)) ? itemOld.Deleted : itemNew.Deleted;
                rs.Description = (itemNew.Description == null || itemNew.Description.Equals(itemOld.Description)) ? itemOld.Description : itemNew.Description;
                rs.DisableBuyButton = (itemNew.DisableBuyButton == null || itemNew.DisableBuyButton.Equals(itemOld.DisableBuyButton)) ? itemOld.DisableBuyButton : itemNew.DisableBuyButton;
                rs.Height = (itemNew.Height == null || itemNew.Height.Equals(itemOld.Height)) ? itemOld.Height : itemNew.Height;
                rs.DisplayOrder = (itemNew.DisplayOrder == null || itemNew.DisplayOrder.Equals(itemOld.DisplayOrder)) ? itemOld.DisplayOrder : itemNew.DisplayOrder;
                rs.IsFreeShipping = (itemNew.IsFreeShipping == null || itemNew.IsFreeShipping.Equals(itemOld.IsFreeShipping)) ? itemOld.IsFreeShipping : itemNew.IsFreeShipping;
                rs.isGift = (itemNew.isGift == null || itemNew.isGift.Equals(itemOld.isGift)) ? itemOld.isGift : itemNew.isGift;
                rs.isHot = (itemNew.isHot == null || itemNew.isHot.Equals(itemOld.isHot)) ? itemOld.isHot : itemNew.isHot;
                rs.isNew = (itemNew.isNew == null || itemNew.isNew.Equals(itemOld.isNew)) ? itemOld.isNew : itemNew.isNew;
                rs.IsShipEnabled = (itemNew.IsShipEnabled == null || itemNew.IsShipEnabled.Equals(itemOld.IsShipEnabled)) ? itemOld.IsShipEnabled : itemNew.IsShipEnabled;
                rs.IsTaxExempt = (itemNew.IsTaxExempt == null || itemNew.IsTaxExempt.Equals(itemOld.IsTaxExempt)) ? itemOld.IsTaxExempt : itemNew.IsTaxExempt;
                rs.Length = (itemNew.Length == null || itemNew.Length.Equals(itemOld.Length)) ? itemOld.Length : itemNew.Length;
                rs.ManageInventory = (itemNew.ManageInventory == null || itemNew.ManageInventory.Equals(itemOld.ManageInventory)) ? itemOld.ManageInventory : itemNew.ManageInventory;
                rs.ManufacturerPartNumber = (itemNew.ManufacturerPartNumber == null || itemNew.ManufacturerPartNumber.Equals(itemOld.ManufacturerPartNumber)) ? itemOld.ManufacturerPartNumber : itemNew.ManufacturerPartNumber;
                rs.Name = (itemNew.Name == null || itemNew.Name.Equals(itemOld.Name)) ? itemOld.Name : itemNew.Name;
                rs.NotifyAdminForQuantityBelow = (itemNew.NotifyAdminForQuantityBelow == null || itemNew.NotifyAdminForQuantityBelow.Equals(itemOld.NotifyAdminForQuantityBelow)) ? itemOld.NotifyAdminForQuantityBelow : itemNew.NotifyAdminForQuantityBelow;
                rs.OldPrice = (itemNew.OldPrice == null || itemNew.OldPrice.Equals(itemOld.OldPrice)) ? itemOld.OldPrice : itemNew.OldPrice;
                rs.OrderMaximumQuantity = (itemNew.OrderMaximumQuantity == null || itemNew.OrderMaximumQuantity.Equals(itemOld.OrderMaximumQuantity)) ? itemOld.OrderMaximumQuantity : itemNew.OrderMaximumQuantity;
                rs.OrderMinimumQuantity = (itemNew.OrderMinimumQuantity == null || itemNew.OrderMinimumQuantity.Equals(itemOld.OrderMinimumQuantity)) ? itemOld.OrderMinimumQuantity : itemNew.OrderMaximumQuantity;
                rs.Price = (itemNew.Price == null || itemNew.Price.Equals(itemOld.Price)) ? itemOld.Price : itemNew.Price;
                rs.ProductCost = (itemNew.ProductCost == null || itemNew.ProductCost.Equals(itemOld.ProductCost)) ? itemOld.ProductCost : itemNew.ProductCost;
                rs.ProductID = (itemNew.ProductID == null || itemNew.ProductID.Equals(itemOld.ProductID)) ? itemOld.ProductID : itemNew.ProductID;
                rs.Published = (itemNew.Published == null || itemNew.Published.Equals(itemOld.Published)) ? itemOld.Published : itemNew.Published;
                rs.SKU = (itemNew.SKU == null || itemNew.SKU.Equals(itemOld.SKU)) ? itemOld.SKU : itemNew.SKU;
                rs.UpdatedOn = (itemNew.UpdatedOn == null || itemNew.UpdatedOn.Equals(itemOld.UpdatedOn)) ? itemOld.UpdatedOn : DateTime.Now;
                rs.WarehouseID = (itemNew.WarehouseID == null || itemNew.WarehouseID.Equals(itemOld.WarehouseID)) ? itemOld.WarehouseID : itemNew.WarehouseID;
                rs.Weight = (itemNew.Weight == null || itemNew.Weight.Equals(itemOld.Weight)) ? itemOld.Weight : itemNew.Weight;
                rs.Width = (itemNew.Width == null || itemNew.Width.Equals(itemOld.Width)) ? itemOld.Width : itemNew.Width;

            }
            return rs;
        }

        public static Fly_ProductVariant_Discount_Mapping UpdateEntity(Fly_ProductVariant_Discount_Mapping itemNew, Fly_ProductVariant_Discount_Mapping itemOld)
        {
            Fly_ProductVariant_Discount_Mapping rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.Createdon = (itemNew.Createdon == null || itemNew.Createdon.Equals(itemOld.Createdon)) ? itemOld.Createdon : DateTime.Now;
                rs.DiscountID = (itemNew.DiscountID.Equals(itemOld.DiscountID)) ? itemOld.DiscountID : itemNew.DiscountID;
                rs.ProductVariantID = (itemNew.ProductVariantID.Equals(itemOld.ProductVariantID)) ? itemOld.ProductVariantID : itemNew.ProductVariantID;
            }
            return rs;
        }

        public static Fly_ProductVariantLocalized UpdateEntity(Fly_ProductVariantLocalized itemNew, Fly_ProductVariantLocalized itemOld)
        {
            Fly_ProductVariantLocalized rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.LanguageID = (itemNew.LanguageID == null || itemNew.LanguageID.Equals(itemOld.LanguageID)) ? itemOld.LanguageID : itemNew.LanguageID;
                rs.Name = (itemNew.Name == null || itemNew.Name.Equals(itemOld.Name)) ? itemOld.Name : itemNew.Name;
                rs.Description = (itemNew.Description == null || itemNew.Description.Equals(itemOld.Description)) ? itemOld.Description : itemNew.Description;
                rs.ProductVariantID = (itemNew.ProductVariantID == null || itemNew.ProductVariantID.Equals(itemOld.ProductVariantID)) ? itemOld.ProductVariantID : itemNew.ProductVariantID;
            }
            return rs;
        }
        
        public static Fly_Product UpdateEntity(Fly_Product itemNew, Fly_Product itemOld)
        {
            Fly_Product rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CreatedOn = (itemNew.CreatedOn == null || itemNew.CreatedOn.Equals(itemOld.CreatedOn)) ? itemOld.CreatedOn : DateTime.Now;
                rs.Name = (itemNew.Name == null || itemNew.Name.Equals(itemOld.Name)) ? itemOld.Name : itemNew.Name;
                rs.Deleted = (itemNew.Deleted == null || itemNew.Deleted.Equals(itemOld.Deleted)) ? itemOld.Deleted : itemNew.Deleted;
                rs.FullDescription = (itemNew.FullDescription == null || itemNew.FullDescription.Equals(itemOld.FullDescription)) ? itemOld.FullDescription : itemNew.FullDescription;
                rs.Published = (itemNew.Published == null || itemNew.Published.Equals(itemOld.Published)) ? itemOld.Published : itemNew.Published;
                rs.ShortDescription = (itemNew.ShortDescription == null || itemNew.ShortDescription.Equals(itemOld.ShortDescription)) ? itemOld.ShortDescription : itemNew.ShortDescription;
                rs.ShowOnHomePage = (itemNew.ShowOnHomePage == null || itemNew.ShowOnHomePage.Equals(itemOld.ShowOnHomePage)) ? itemOld.ShowOnHomePage : itemNew.ShowOnHomePage;
                rs.TemplateID = (itemNew.TemplateID == null || itemNew.TemplateID.Equals(itemOld.TemplateID)) ? itemOld.TemplateID : itemNew.TemplateID;
                rs.UpdatedOn = (itemNew.UpdatedOn == null || itemNew.UpdatedOn.Equals(itemOld.UpdatedOn)) ? itemOld.UpdatedOn : DateTime.Now;
            }
            return rs;
        }

        public static Fly_RelatedProduct UpdateEntity(Fly_RelatedProduct itemNew, Fly_RelatedProduct itemOld)
        {
            Fly_RelatedProduct rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.ProductID1 = (itemNew.ProductID1 == null || itemNew.ProductID1.Equals(itemOld.ProductID1)) ? itemOld.ProductID1 : itemNew.ProductID1;
                rs.ProductID2 = (itemNew.ProductID2 == null || itemNew.ProductID2.Equals(itemOld.ProductID2)) ? itemOld.ProductID2 : itemNew.ProductID2;
                rs.RelatedProductID = (itemNew.RelatedProductID.Equals(itemOld.RelatedProductID)) ? itemOld.RelatedProductID : itemNew.RelatedProductID;
            }
            return rs;
        }

        public static Fly_Customer_CustomerRole_Mapping UpdateEntity(Fly_Customer_CustomerRole_Mapping itemNew, Fly_Customer_CustomerRole_Mapping itemOld)
        {
            Fly_Customer_CustomerRole_Mapping rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CustomerID = (itemNew.CustomerID.Equals(itemOld.CustomerID)) ? itemOld.CustomerID : itemNew.CustomerID;
                rs.CustomerRoleID = (itemNew.CustomerRoleID.Equals(itemOld.CustomerRoleID)) ? itemOld.CustomerRoleID : itemNew.CustomerRoleID;
                rs.Creadedon = (itemNew.Creadedon.Equals(itemOld.Creadedon)) ? itemOld.Creadedon : itemNew.Creadedon;
            }
            return rs;
        }

        public static Fly_Customer UpdateEntity(Fly_Customer itemNew, Fly_Customer itemOld)
        {
            Fly_Customer rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CustomerID = (itemNew.CustomerID.Equals(itemOld.CustomerID)) ? itemOld.CustomerID : itemNew.CustomerID;
                rs.Email = (itemNew.Email != null && !itemNew.Email.Equals(itemOld.Email)) ? itemOld.Email : itemNew.Email;
                rs.Username = (itemNew.Username != null && !itemNew.Username.Equals(itemOld.Username)) ? itemOld.Username : itemNew.Username;
                rs.IsTaxExempt = (itemNew.IsTaxExempt.Equals(itemOld.IsTaxExempt)) ? itemOld.IsTaxExempt : itemNew.IsTaxExempt;
                rs.IsAdmin = (itemNew.IsAdmin.Equals(itemOld.IsAdmin)) ? itemOld.IsAdmin : itemNew.IsAdmin;
                rs.Active = (itemNew.Active.Equals(itemOld.Active)) ? itemOld.Active : itemNew.Active;
                rs.IsGuest = (itemNew.IsGuest.Equals(itemOld.IsGuest)) ? itemOld.IsGuest : itemNew.IsGuest;
                rs.Deleted = (itemNew.Deleted.Equals(itemOld.Deleted)) ? itemOld.Deleted : itemNew.Deleted;
                rs.RegistrationDate = (itemNew.RegistrationDate.Equals(itemOld.RegistrationDate)) ? itemOld.RegistrationDate : itemNew.RegistrationDate;
                rs.AvatarID = (itemNew.AvatarID.Equals(itemOld.AvatarID)) ? itemOld.AvatarID : itemNew.AvatarID;
                rs.DateOfBirth = (itemNew.DateOfBirth.Equals(itemOld.DateOfBirth)) ? itemOld.DateOfBirth : itemNew.DateOfBirth;
            }
            return rs;
        }

        public static Fly_CustomerAttribute UpdateEntity(Fly_CustomerAttribute itemNew, Fly_CustomerAttribute itemOld)
        {
            Fly_CustomerAttribute rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CustomerId = (itemNew.CustomerId.Equals(itemOld.CustomerId)) ? itemOld.CustomerId : itemNew.CustomerId;
                rs.FirstName = (itemNew.FirstName != null && itemNew.FirstName.Equals(itemOld.FirstName)) ? itemOld.FirstName : itemNew.FirstName;
                rs.LastName = (itemNew.LastName != null && itemNew.LastName.Equals(itemOld.LastName)) ? itemOld.LastName : itemNew.LastName;
                rs.StreetAddress = (itemNew.StreetAddress != null && itemNew.StreetAddress.Equals(itemOld.StreetAddress)) ? itemOld.StreetAddress : itemNew.StreetAddress;
                rs.City = (itemNew.City != null && itemNew.City.Equals(itemOld.City)) ? itemOld.City : itemNew.City;
                rs.CountryID = (itemNew.CountryID != null && itemNew.CountryID.Equals(itemOld.CountryID)) ? itemOld.CountryID : itemNew.CountryID;
                rs.MobilePhone = (itemNew.MobilePhone != null && itemNew.MobilePhone.Equals(itemOld.MobilePhone)) ? itemOld.MobilePhone : itemNew.MobilePhone;
            }
            return rs;
        }

        public static Fly_CustomerAction UpdateEntity(Fly_CustomerAction itemNew, Fly_CustomerAction itemOld)
        {
            Fly_CustomerAction rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.Name = (itemNew.Name.Equals(itemOld.Name)) ? itemOld.Name : itemNew.Name;
                rs.SystemKeyword = (itemNew.SystemKeyword.Equals(itemOld.SystemKeyword)) ? itemOld.SystemKeyword : itemNew.SystemKeyword;
                rs.Description = (itemNew.Description.Equals(itemOld.Description)) ? itemOld.Description : itemNew.Description;
                rs.DisplayOrder = (itemNew.DisplayOrder.Equals(itemOld.DisplayOrder)) ? itemOld.DisplayOrder : itemNew.DisplayOrder;
            }
            return rs;
        }

        public static Fly_CustomerRole UpdateEntity(Fly_CustomerRole itemNew, Fly_CustomerRole itemOld)
        {
            Fly_CustomerRole rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.Name = (itemNew.Name.Equals(itemOld.Name)) ? itemOld.Name : itemNew.Name;
                rs.FreeShipping = (itemNew.FreeShipping.Equals(itemOld.FreeShipping)) ? itemOld.FreeShipping : itemNew.FreeShipping;
                rs.TaxExempt = (itemNew.TaxExempt.Equals(itemOld.TaxExempt)) ? itemOld.TaxExempt : itemNew.TaxExempt;
                rs.Active = (itemNew.Active.Equals(itemOld.Active)) ? itemOld.Active : itemNew.Active;
                rs.Deleted = (itemNew.Deleted.Equals(itemOld.Deleted)) ? itemOld.Deleted : itemNew.Deleted;
            }
            return rs;
        }

        public static Fly_CustomerRole_Discount_Mapping UpdateEntity(Fly_CustomerRole_Discount_Mapping itemNew, Fly_CustomerRole_Discount_Mapping itemOld)
        {
            Fly_CustomerRole_Discount_Mapping rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CustomerRoleID = (itemNew.CustomerRoleID.Equals(itemOld.CustomerRoleID)) ? itemOld.CustomerRoleID : itemNew.CustomerRoleID;
                rs.DiscountID = (itemNew.DiscountID.Equals(itemOld.DiscountID)) ? itemOld.DiscountID : itemNew.DiscountID;
                rs.Creadedon = (itemNew.Creadedon.Equals(itemOld.Creadedon)) ? itemOld.Creadedon : itemNew.Creadedon;
            }
            return rs;
        }

        public static Fly_CustomerRole_ProductPrice UpdateEntity(Fly_CustomerRole_ProductPrice itemNew, Fly_CustomerRole_ProductPrice itemOld)
        {
            Fly_CustomerRole_ProductPrice rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CustomerRoleID = (itemNew.CustomerRoleID.Equals(itemOld.CustomerRoleID)) ? itemOld.CustomerRoleID : itemNew.CustomerRoleID;
                rs.ProductVariantID = (itemNew.ProductVariantID.Equals(itemOld.ProductVariantID)) ? itemOld.ProductVariantID : itemNew.ProductVariantID;
                rs.Price = (itemNew.Price.Equals(itemOld.Price)) ? itemOld.Price : itemNew.Price;
            }
            return rs;
        }

        public static Fly_CustomerSession UpdateEntity(Fly_CustomerSession itemNew, Fly_CustomerSession itemOld)
        {
            Fly_CustomerSession rs = itemOld;
            if (itemNew != null && itemOld != null)
            {
                rs.CustomerID = (itemNew.CustomerID.Equals(itemOld.CustomerID)) ? itemOld.CustomerID : itemNew.CustomerID;
                rs.LastAccessed = (itemNew.LastAccessed.Equals(itemOld.LastAccessed)) ? itemOld.LastAccessed : itemNew.LastAccessed;
                rs.IsExpired = (itemNew.IsExpired.Equals(itemOld.IsExpired)) ? itemOld.IsExpired : itemNew.IsExpired;
            }
            return rs;
        }
    }
}
