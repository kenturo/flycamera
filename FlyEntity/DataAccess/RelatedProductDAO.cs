using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace FlyEntity.DataAccess
{
    public class RelatedProductDAO : IRepositryRelateProducts<Fly_RelatedProduct>
    {
        public IList<Fly_RelatedProduct> getAllItems()
        {
            IList<Fly_RelatedProduct> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_RelatedProduct>();
                    item = context.Fly_RelatedProduct.Include("Fly_Product").ToList<Fly_RelatedProduct>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_RelatedProduct obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_RelatedProduct.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_RelatedProduct obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_RelatedProduct.Find(obj.RelatedProductID);
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj, item));
                        context.SaveChanges();
                    }
                    else
                    {
                        this.Add(obj);
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
                    var item = context.Fly_RelatedProduct.Find(id);
                    if (item != null)
                    {
                        context.Fly_RelatedProduct.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_RelatedProduct getItem(int id)
        {
            Fly_RelatedProduct obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_RelatedProduct.Where(x => x.RelatedProductID == id).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public IList<Fly_RelatedProduct> getAllItemsByProductID(int id)
        {
            IList<Fly_RelatedProduct> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_RelatedProduct>();
                    item = context.Fly_RelatedProduct
                        .Where(x=>x.ProductID1 == id).ToList<Fly_RelatedProduct>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

    }
}
