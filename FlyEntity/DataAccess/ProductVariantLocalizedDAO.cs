using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class ProductVariantLocalizedDAO: IRepositryBase<Fly_ProductVariantLocalized>
    {
        public IList<Fly_ProductVariantLocalized> getAllItems()
        {
            IList<Fly_ProductVariantLocalized> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ProductVariantLocalized>();
                    item = context.Fly_ProductVariantLocalized.Include("Fly_Language").Include("Fly_ProductVariant").ToList<Fly_ProductVariantLocalized>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ProductVariantLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ProductVariantLocalized.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ProductVariantLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ProductVariantLocalized.Where(x => x.ProductVariantID == obj.ProductVariantID).FirstOrDefault();
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
                    var item = context.Fly_ProductVariantLocalized.Where(x => x.ProductVariantID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_ProductVariantLocalized.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ProductVariantLocalized getItem(int id)
        {
            Fly_ProductVariantLocalized obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ProductVariantLocalized.Where(x => x.ProductVariantID == id).FirstOrDefault();
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
