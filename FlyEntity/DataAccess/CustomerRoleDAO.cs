using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class CustomerRoleDAO: IRepositryBase<Fly_CustomerRole>
    {
        public IList<Fly_CustomerRole> getAllItems()
        {
            IList<Fly_CustomerRole> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_CustomerRole>();
                    item = (from it in context.Fly_CustomerRole
                            select it).ToList<Fly_CustomerRole>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_CustomerRole obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_CustomerRole.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_CustomerRole obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_CustomerRole.FirstOrDefault(x => x.CustomerRoleID == obj.CustomerRoleID);
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
                    var item = context.Fly_CustomerRole.FirstOrDefault(x => x.CustomerRoleID == id);
                    if (item != null)
                    {
                        context.Fly_CustomerRole.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_CustomerRole getItem(int id)
        {
            Fly_CustomerRole obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_CustomerRole.FirstOrDefault(x => x.CustomerRoleID == id);
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
