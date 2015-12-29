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
    public class ProductPictureDAO: IRepositryBase<Fly_ProductPicture>
    {
        public IList<Fly_ProductPicture> getAllItems()
        {
            IList<Fly_ProductPicture> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ProductPicture>();
                    item = context.Fly_ProductPicture.Include("Fly_Picture").Include("Fly_Product").ToList<Fly_ProductPicture>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ProductPicture obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ProductPicture.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ProductPicture obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ProductPicture.Where(x => x.ProductID == obj.ProductID).FirstOrDefault();
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
                    var item = context.Fly_ProductPicture.Where(x => x.ProductID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_ProductPicture.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ProductPicture getItem(int id)
        {
            Fly_ProductPicture obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ProductPicture.Where(x => x.ProductID == id).FirstOrDefault();
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
