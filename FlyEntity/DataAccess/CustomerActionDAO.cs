using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class CustomerActionDAO: IRepositryBase<Fly_CustomerAction>
    {
        public IList<Fly_CustomerAction> getAllItems()
        {
            IList<Fly_CustomerAction> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_CustomerAction>();
                    item = (from it in context.Fly_CustomerAction
                            select it).ToList<Fly_CustomerAction>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_CustomerAction obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_CustomerAction.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_CustomerAction obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_CustomerAction.Where(x => x.CustomerActionID == obj.CustomerActionID).FirstOrDefault();
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
                    var item = context.Fly_CustomerAction.Where(x => x.CustomerActionID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_CustomerAction.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_CustomerAction getItem(int id)
        {
            Fly_CustomerAction obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_CustomerAction.Where(x => x.CustomerActionID == id).FirstOrDefault();
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
