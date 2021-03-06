//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlyEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fly_ProductVariant
    {
        public Fly_ProductVariant()
        {
            this.Fly_CustomerRole_ProductPrice = new HashSet<Fly_CustomerRole_ProductPrice>();
            this.Fly_OrderProductVariant = new HashSet<Fly_OrderProductVariant>();
            this.Fly_ProductVariant_Discount_Mapping = new HashSet<Fly_ProductVariant_Discount_Mapping>();
            this.Fly_ProductVariantLocalized = new HashSet<Fly_ProductVariantLocalized>();
            this.Fly_ShoppingCartItem = new HashSet<Fly_ShoppingCartItem>();
        }
    
        public int ProductVariantId { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public Nullable<bool> IsShipEnabled { get; set; }
        public Nullable<bool> IsFreeShipping { get; set; }
        public Nullable<decimal> AdditionalShippingCharge { get; set; }
        public Nullable<bool> IsTaxExempt { get; set; }
        public Nullable<int> ManageInventory { get; set; }
        public Nullable<int> NotifyAdminForQuantityBelow { get; set; }
        public Nullable<int> Backorders { get; set; }
        public Nullable<int> OrderMinimumQuantity { get; set; }
        public Nullable<int> OrderMaximumQuantity { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<bool> DisableBuyButton { get; set; }
        public Nullable<bool> CallForPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public Nullable<decimal> ProductCost { get; set; }
        public Nullable<decimal> AdminPrice { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<bool> Published { get; set; }
        public Nullable<bool> isHot { get; set; }
        public Nullable<bool> isNew { get; set; }
        public Nullable<bool> isGift { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual ICollection<Fly_CustomerRole_ProductPrice> Fly_CustomerRole_ProductPrice { get; set; }
        public virtual ICollection<Fly_OrderProductVariant> Fly_OrderProductVariant { get; set; }
        public virtual Fly_Product Fly_Product { get; set; }
        public virtual ICollection<Fly_ProductVariant_Discount_Mapping> Fly_ProductVariant_Discount_Mapping { get; set; }
        public virtual ICollection<Fly_ProductVariantLocalized> Fly_ProductVariantLocalized { get; set; }
        public virtual ICollection<Fly_ShoppingCartItem> Fly_ShoppingCartItem { get; set; }
    }
}
