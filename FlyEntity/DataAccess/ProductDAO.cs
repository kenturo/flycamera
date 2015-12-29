using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace FlyEntity.DataAccess
{
    public class ProductDAO : IRepositryBase<Fly_Product>
    {

        public IList<Fly_Product> getAllItems()
        {
            IList<Fly_Product> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Product>();
                    item = context.Fly_Product
                        .Include("Fly_ProductVariant.Fly_ProductVariantLocalized")
                        .Include("Fly_ProductVariant.Fly_ProductVariant_Discount_Mapping")
                        .Include("Fly_ProductLocalized")
                        .Include("Fly_SectionContent")
                        .Include("Fly_SectionGallery")
                        .Include("Fly_SectionGallery.Fly_PositionGallery")
                        .Include("Fly_Product_Category_Mapping")
                        .Include("Fly_Product_Manufacturer_Mapping")
                        .Include("Fly_ProductPicture.Fly_Picture").ToList<Fly_Product>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Product obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Product.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Product obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var product = context.Fly_Product
                        .Include("Fly_ProductVariant.Fly_ProductVariantLocalized")
                        .Include("Fly_ProductVariant.Fly_ProductVariant_Discount_Mapping")
                        .Include("Fly_SectionGallery.Fly_PositionGallery")
                        .Include("Fly_ProductLocalized")
                        .Include("Fly_Product_Category_Mapping")
                        .Include("Fly_Product_Manufacturer_Mapping")
                        .Include("Fly_ProductPicture.Fly_Picture").FirstOrDefault(x => x.ProductId == obj.ProductId);

                    // old Entity Data
                    if (product != null)
                    {
                        var mappingCate = product.Fly_Product_Category_Mapping.FirstOrDefault();
                        var mappingManufacturer = product.Fly_Product_Manufacturer_Mapping.FirstOrDefault();
                        var productLocalized = product.Fly_ProductLocalized.FirstOrDefault();
                        var productPicture = product.Fly_ProductPicture.FirstOrDefault();
                        var productVariant = product.Fly_ProductVariant.FirstOrDefault();
                        if (productVariant != null)
                        {
                            var mappingVariantDiscount = productVariant.Fly_ProductVariant_Discount_Mapping.FirstOrDefault();
                            var mappingVariantLocalized = productVariant.Fly_ProductVariantLocalized.FirstOrDefault();

                            // new Entity Data
                            var productVariantNew = obj.Fly_ProductVariant.FirstOrDefault();


                            if (mappingCate != null)
                                context.Entry(mappingCate).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj.Fly_Product_Category_Mapping.FirstOrDefault(), mappingCate));

                            if (mappingManufacturer != null)
                                context.Entry(mappingManufacturer).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj.Fly_Product_Manufacturer_Mapping.FirstOrDefault(),mappingManufacturer));

                            if (productLocalized != null)
                                context.Entry(productLocalized).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj.Fly_ProductLocalized.FirstOrDefault(), productLocalized));

                            if (productPicture != null)
                                context.Entry(productPicture).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj.Fly_ProductPicture.FirstOrDefault(), productPicture));

                            context.Entry(productVariant).CurrentValues.SetValues(UpdateEntities.UpdateEntity(productVariantNew,productVariant));

                            if (mappingVariantLocalized != null)
                                if (productVariantNew != null)
                                    context.Entry(mappingVariantLocalized).CurrentValues.SetValues(UpdateEntities.UpdateEntity(productVariantNew.Fly_ProductVariantLocalized.FirstOrDefault(), mappingVariantLocalized));

                            if (mappingVariantDiscount != null)
                                if (productVariantNew != null)
                                    context.Entry(mappingVariantDiscount).CurrentValues.SetValues(UpdateEntities.UpdateEntity(productVariantNew.Fly_ProductVariant_Discount_Mapping.FirstOrDefault(), mappingVariantDiscount));

                            if (mappingVariantDiscount != null)
                                if (productVariantNew != null)
                                    context.Entry(mappingVariantDiscount).CurrentValues.SetValues(UpdateEntities.UpdateEntity(productVariantNew.Fly_ProductVariant_Discount_Mapping.FirstOrDefault(), mappingVariantDiscount));

                            context.Entry(product).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj, product));

                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Product.Find(id);
                    if (item != null)
                    {
                        context.Fly_Product.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Fly_Product getItem(int id)
        {
            Fly_Product obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Product
                        .Include("Fly_ProductVariant.Fly_ProductVariantLocalized")
                        .Include("Fly_ProductVariant.Fly_ProductVariant_Discount_Mapping")
                        .Include("Fly_ProductLocalized")
                        .Include("Fly_SectionContent.Fly_PositionGallery")
                        .Include("Fly_SectionGallery")
                        .Include("Fly_SectionGallery.Fly_PositionGallery")
                        .Include("Fly_Product_Category_Mapping")
                        .Include("Fly_Product_Category_Mapping.Fly_Category")
                        .Include("Fly_Product_Manufacturer_Mapping")
                        .Include("Fly_Product_Manufacturer_Mapping.Fly_Manufacturer")
                        .Include("Fly_ProductPicture.Fly_Picture").FirstOrDefault(x => x.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

    }
}

