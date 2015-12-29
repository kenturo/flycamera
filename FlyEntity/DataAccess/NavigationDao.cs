using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class NavigationDao:IRepositryBase<Fly_Navigation>
    {

        public IList<Fly_Navigation> getAllItems()
        {
            IList<Fly_Navigation> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Navigation>();
                    item = (from it in context.Fly_Navigation
                            select it).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Navigation obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Navigation.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Navigation obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Navigation.FirstOrDefault(x => x.navid == obj.navid);
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
                    var item = context.Fly_Navigation.FirstOrDefault(x => x.navid == id);
                    if (item != null)
                    {
                        context.Fly_Navigation.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Navigation getItem(int id)
        {
            Fly_Navigation obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Navigation.FirstOrDefault(x => x.navid == id);
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