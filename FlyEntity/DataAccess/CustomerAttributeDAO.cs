using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class CustomerAttributeDAO: IRepositryBase<Fly_CustomerAttribute>
    {
        public IList<Fly_CustomerAttribute> getAllItems()
        {
            IList<Fly_CustomerAttribute> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_CustomerAttribute>();
                    item = context.Fly_CustomerAttribute.Include("Fly_Country").Include("Fly_Customer").ToList<Fly_CustomerAttribute>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_CustomerAttribute obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_CustomerAttribute.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_CustomerAttribute obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_CustomerAttribute.Where(x => x.CustomerId == obj.CustomerId).FirstOrDefault();
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
                    var item = context.Fly_CustomerAttribute.Where(x => x.CustomerId == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_CustomerAttribute.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_CustomerAttribute getItem(int id)
        {
            Fly_CustomerAttribute obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_CustomerAttribute.Where(x => x.CustomerId == id).FirstOrDefault();
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
