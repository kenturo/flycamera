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
    public class ProductVariantDAO: IRepositryBase<Fly_ProductVariant>
    {
        public IList<Fly_ProductVariant> getAllItems()
        {
            IList<Fly_ProductVariant> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ProductVariant>();
                    item = context.Fly_ProductVariant.Include("Fly_Product").ToList<Fly_ProductVariant>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ProductVariant obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ProductVariant.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ProductVariant obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ProductVariant.Where(x => x.ProductID == obj.ProductID).FirstOrDefault();
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
                    var item = context.Fly_ProductVariant.Where(x => x.ProductID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_ProductVariant.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ProductVariant getItem(int id)
        {
            Fly_ProductVariant obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ProductVariant.Where(x => x.ProductID == id).FirstOrDefault();
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
