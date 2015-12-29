using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class BannerTypeDAO: IRepositryBase<Fly_BannerType>
    {

        public IList<Fly_BannerType> getAllItems()
        {
            IList<Fly_BannerType> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_BannerType>();
                    item = context.Fly_BannerType.Include("Fly_Customer").ToList<Fly_BannerType>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_BannerType obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_BannerType.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_BannerType obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_BannerType.Where(x => x.BannerTypeID == obj.BannerTypeID).FirstOrDefault();
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
                    var item = context.Fly_BannerType.Where(x => x.BannerTypeID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_BannerType.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_BannerType getItem(int id)
        {
            Fly_BannerType obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_BannerType.Where(x => x.BannerTypeID == id).FirstOrDefault();
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
