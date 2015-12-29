using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class BlogPostDAO: IRepositryBase<Fly_BlogPost>
    {
        public IList<Fly_BlogPost> getAllItems()
        {
            IList<Fly_BlogPost> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_BlogPost>();
                    item = context.Fly_BlogPost.Include("Fly_BlogPostType").Include("Fly_Customer").ToList<Fly_BlogPost>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_BlogPost obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_BlogPost.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_BlogPost obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_BlogPost.FirstOrDefault(x => x.BlogPostID == obj.BlogPostID);
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
                    var item = context.Fly_BlogPost.FirstOrDefault(x => x.BlogPostID == id);
                    if (item != null)
                    {
                        context.Fly_BlogPost.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_BlogPost getItem(int id)
        {
            Fly_BlogPost obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_BlogPost.FirstOrDefault(x => x.BlogPostID == id);
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
