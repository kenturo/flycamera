using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class CustomerSessionDAO: IRepositryBase<Fly_CustomerSession>
    {
        public IList<Fly_CustomerSession> getAllItems()
        {
            IList<Fly_CustomerSession> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_CustomerSession>();
                    item = context.Fly_CustomerSession.Include("Fly_Customer").ToList<Fly_CustomerSession>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_CustomerSession obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_CustomerSession.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_CustomerSession obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_CustomerSession.Where(x => x.CustomerID == obj.CustomerID).FirstOrDefault();
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
                    var item = context.Fly_CustomerSession.Where(x => x.CustomerID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_CustomerSession.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_CustomerSession getItem(int id)
        {
            Fly_CustomerSession obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_CustomerSession.Where(x => x.CustomerID == id).FirstOrDefault();
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
