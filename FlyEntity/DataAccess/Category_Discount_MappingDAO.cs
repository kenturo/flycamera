using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
using System.Data.Entity.Validation;

namespace FlyEntity.DataAccess
{
    public class Category_Discount_MappingDAO : IRepositryBase<Fly_Category_Discount_Mapping>
    {
        public IList<Fly_Category_Discount_Mapping> getAllItems()
        {
            IList<Fly_Category_Discount_Mapping> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Category_Discount_Mapping>();
                    item = (from it in context.Fly_Category_Discount_Mapping
                            select it).ToList<Fly_Category_Discount_Mapping>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Category_Discount_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Category_Discount_Mapping.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Category_Discount_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Category_Discount_Mapping.Where(x => x.CategoryID == obj.CategoryID).FirstOrDefault();
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
                    var item = context.Fly_Category_Discount_Mapping.Where(x => x.CategoryID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_Category_Discount_Mapping.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Category_Discount_Mapping getItem(int id)
        {
            Fly_Category_Discount_Mapping obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Category_Discount_Mapping.Where(x => x.CategoryID == id).FirstOrDefault();
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
