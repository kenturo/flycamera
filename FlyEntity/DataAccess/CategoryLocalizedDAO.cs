using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class CategoryLocalizedDAO: IRepositryBase<Fly_CategoryLocalized>
    {
        public IList<Fly_CategoryLocalized> getAllItems()
        {
            IList<Fly_CategoryLocalized> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_CategoryLocalized>();
                    item = context.Fly_CategoryLocalized.Include("Fly_Language").Include("Fly_Category").ToList<Fly_CategoryLocalized>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_CategoryLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_CategoryLocalized.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_CategoryLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_CategoryLocalized.Where(x => x.CategoryID == obj.CategoryID).FirstOrDefault();
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
                    var item = context.Fly_CategoryLocalized.Where(x => x.CategoryID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_CategoryLocalized.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_CategoryLocalized getItem(int id)
        {
            Fly_CategoryLocalized obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_CategoryLocalized.Where(x => x.CategoryID == id).FirstOrDefault();
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
