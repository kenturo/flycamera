using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class ProductVariant_Discount_MappingDAO: IRepositryBase<Fly_ProductVariant_Discount_Mapping>
    {
        public IList<Fly_ProductVariant_Discount_Mapping> getAllItems()
        {
            IList<Fly_ProductVariant_Discount_Mapping> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ProductVariant_Discount_Mapping>();
                    item = context.Fly_ProductVariant_Discount_Mapping.Include("Fly_Discount").Include("Fly_ProductVariant").ToList<Fly_ProductVariant_Discount_Mapping>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ProductVariant_Discount_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ProductVariant_Discount_Mapping.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ProductVariant_Discount_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ProductVariant_Discount_Mapping.Where(x => x.ProductVariantID == obj.ProductVariantID).FirstOrDefault();
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
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
                    var item = context.Fly_ProductVariant_Discount_Mapping.Where(x => x.ProductVariantID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_ProductVariant_Discount_Mapping.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ProductVariant_Discount_Mapping getItem(int id)
        {
            Fly_ProductVariant_Discount_Mapping obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ProductVariant_Discount_Mapping.Where(x => x.ProductVariantID == id).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
