﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class flycameraEntities : DbContext
    {
        public flycameraEntities()
            : base("name=flycameraEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Fly_Banner> Fly_Banner { get; set; }
        public DbSet<Fly_BannerType> Fly_BannerType { get; set; }
        public DbSet<Fly_BlogPost> Fly_BlogPost { get; set; }
        public DbSet<Fly_BlogPostType> Fly_BlogPostType { get; set; }
        public DbSet<Fly_Category> Fly_Category { get; set; }
        public DbSet<Fly_Category_Discount_Mapping> Fly_Category_Discount_Mapping { get; set; }
        public DbSet<Fly_CategoryLocalized> Fly_CategoryLocalized { get; set; }
        public DbSet<Fly_Country> Fly_Country { get; set; }
        public DbSet<Fly_Customer> Fly_Customer { get; set; }
        public DbSet<Fly_Customer_CustomerRole_Mapping> Fly_Customer_CustomerRole_Mapping { get; set; }
        public DbSet<Fly_CustomerAction> Fly_CustomerAction { get; set; }
        public DbSet<Fly_CustomerAttribute> Fly_CustomerAttribute { get; set; }
        public DbSet<Fly_CustomerRole> Fly_CustomerRole { get; set; }
        public DbSet<Fly_CustomerRole_Discount_Mapping> Fly_CustomerRole_Discount_Mapping { get; set; }
        public DbSet<Fly_CustomerRole_ProductPrice> Fly_CustomerRole_ProductPrice { get; set; }
        public DbSet<Fly_CustomerSession> Fly_CustomerSession { get; set; }
        public DbSet<Fly_Discount> Fly_Discount { get; set; }
        public DbSet<Fly_DiscountUsageHistory> Fly_DiscountUsageHistory { get; set; }
        public DbSet<Fly_Language> Fly_Language { get; set; }
        public DbSet<Fly_Manufacturer> Fly_Manufacturer { get; set; }
        public DbSet<Fly_ManufacturerLocalized> Fly_ManufacturerLocalized { get; set; }
        public DbSet<Fly_Navigation> Fly_Navigation { get; set; }
        public DbSet<Fly_Order> Fly_Order { get; set; }
        public DbSet<Fly_OrderNote> Fly_OrderNote { get; set; }
        public DbSet<Fly_OrderProductVariant> Fly_OrderProductVariant { get; set; }
        public DbSet<Fly_Partnership> Fly_Partnership { get; set; }
        public DbSet<Fly_PaymentMethod> Fly_PaymentMethod { get; set; }
        public DbSet<Fly_Picture> Fly_Picture { get; set; }
        public DbSet<Fly_PositionGallery> Fly_PositionGallery { get; set; }
        public DbSet<Fly_Product> Fly_Product { get; set; }
        public DbSet<Fly_Product_Category_Mapping> Fly_Product_Category_Mapping { get; set; }
        public DbSet<Fly_Product_Manufacturer_Mapping> Fly_Product_Manufacturer_Mapping { get; set; }
        public DbSet<Fly_ProductLocalized> Fly_ProductLocalized { get; set; }
        public DbSet<Fly_ProductPicture> Fly_ProductPicture { get; set; }
        public DbSet<Fly_ProductTemplate> Fly_ProductTemplate { get; set; }
        public DbSet<Fly_ProductVariant> Fly_ProductVariant { get; set; }
        public DbSet<Fly_ProductVariant_Discount_Mapping> Fly_ProductVariant_Discount_Mapping { get; set; }
        public DbSet<Fly_ProductVariantLocalized> Fly_ProductVariantLocalized { get; set; }
        public DbSet<Fly_RelatedProduct> Fly_RelatedProduct { get; set; }
        public DbSet<Fly_SectionContent> Fly_SectionContent { get; set; }
        public DbSet<Fly_SectionGallery> Fly_SectionGallery { get; set; }
        public DbSet<Fly_ShippingMethod> Fly_ShippingMethod { get; set; }
        public DbSet<Fly_ShippingStatus> Fly_ShippingStatus { get; set; }
        public DbSet<Fly_ShoppingCartItem> Fly_ShoppingCartItem { get; set; }
        public DbSet<Fly_Videos> Fly_Videos { get; set; }
        public DbSet<Fly_Team> Fly_Team { get; set; }
    }
}
