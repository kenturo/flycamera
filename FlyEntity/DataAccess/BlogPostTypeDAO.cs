using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class BlogPostTypeDAO: IRepositryBase<Fly_BlogPostType>
    {
        public IList<Fly_BlogPostType> getAllItems()
        {
            IList<Fly_BlogPostType> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_BlogPostType>();
                    item = context.Fly_BlogPostType.ToList<Fly_BlogPostType>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_BlogPostType obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_BlogPostType.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_BlogPostType obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_BlogPostType.FirstOrDefault(x => x.BlogPostTypeID == obj.BlogPostTypeID);
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
                    var item = context.Fly_BlogPostType.FirstOrDefault(x => x.BlogPostTypeID == id);
                    if (item != null)
                    {
                        context.Fly_BlogPostType.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_BlogPostType getItem(int id)
        {
            Fly_BlogPostType obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_BlogPostType.FirstOrDefault(x => x.BlogPostTypeID == id);
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
