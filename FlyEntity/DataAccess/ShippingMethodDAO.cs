using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class ShippingMethodDao : IRepositryBase<Fly_ShippingMethod>
    {
        public IList<Fly_ShippingMethod> getAllItems()
        {
            IList<Fly_ShippingMethod> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ShippingMethod>();
                    item = (from it in context.Fly_ShippingMethod
                            select it).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ShippingMethod obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ShippingMethod.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ShippingMethod obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ShippingMethod.FirstOrDefault(x => x.ShippingMethodID == obj.ShippingMethodID);
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
                    var item = context.Fly_ShippingMethod.FirstOrDefault(x => x.ShippingMethodID == id);
                    if (item != null)
                    {
                        context.Fly_ShippingMethod.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ShippingMethod getItem(int id)
        {
            Fly_ShippingMethod obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ShippingMethod.FirstOrDefault(x => x.ShippingMethodID == id);
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
