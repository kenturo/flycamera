using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
using System.Data.Entity.Validation;

namespace FlyEntity.DataAccess
{
    public class BannerDAO : IRepositryBase<Fly_Banner>
    {
        public IList<Fly_Banner> getAllItems()
        {
            IList<Fly_Banner> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Banner>();
                    item = context.Fly_Banner.Include("Fly_Customer").Include("Fly_Picture").Include("Fly_BannerType").ToList<Fly_Banner>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Banner obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Banner.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Banner obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Banner.FirstOrDefault(x => x.BannerID == obj.BannerID);
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
                    var item = context.Fly_Banner.FirstOrDefault(x => x.BannerID == id);
                    if (item != null)
                    {
                        item.Deleted = true;
                        context.Entry(item).CurrentValues.SetValues((Fly_Banner)item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Banner getItem(int id)
        {
            Fly_Banner obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Banner.Include("Fly_Picture").FirstOrDefault(x => x.BannerID == id);
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
