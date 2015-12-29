using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class CountryDAO: IRepositryBase<Fly_Country>
    {
        public IList<Fly_Country> getAllItems()
        {
            IList<Fly_Country> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Country>();
                    item = (from it in context.Fly_Country
                            select it).ToList<Fly_Country>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Country obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Country.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Country obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Country.Where(x => x.CountryID == obj.CountryID).FirstOrDefault();
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
                    var item = context.Fly_Country.Where(x => x.CountryID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_Country.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Country getItem(int id)
        {
            Fly_Country obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Country.Where(x => x.CountryID == id).FirstOrDefault();
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
