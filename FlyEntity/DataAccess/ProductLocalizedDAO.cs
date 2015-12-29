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
    public class ProductLocalizedDAO: IRepositryBase<Fly_ProductLocalized>
    {
        public IList<Fly_ProductLocalized> getAllItems()
        {
            IList<Fly_ProductLocalized> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ProductLocalized>();
                    item = context.Fly_ProductLocalized.Include("Fly_Language").Include("Fly_Product").ToList<Fly_ProductLocalized>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ProductLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ProductLocalized.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ProductLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ProductLocalized.Where(x => x.ProductID == obj.ProductID).FirstOrDefault();
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
                    var item = context.Fly_ProductLocalized.Where(x => x.ProductID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_ProductLocalized.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ProductLocalized getItem(int id)
        {
            Fly_ProductLocalized obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ProductLocalized.Where(x => x.ProductID == id).FirstOrDefault();
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
