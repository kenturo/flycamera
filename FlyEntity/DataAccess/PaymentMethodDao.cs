using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class PaymentMethodDao : IRepositryBase<Fly_PaymentMethod>
    {
        public IList<Fly_PaymentMethod> getAllItems()
        {
            IList<Fly_PaymentMethod> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_PaymentMethod>();
                    item = (from it in context.Fly_PaymentMethod
                            select it).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_PaymentMethod obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_PaymentMethod.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_PaymentMethod obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_PaymentMethod.FirstOrDefault(x => x.PaymentMethodID == obj.PaymentMethodID);
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
                    var item = context.Fly_PaymentMethod.FirstOrDefault(x => x.PaymentMethodID == id);
                    if (item != null)
                    {
                        context.Fly_PaymentMethod.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_PaymentMethod getItem(int id)
        {
            Fly_PaymentMethod obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_PaymentMethod.FirstOrDefault(x => x.PaymentMethodID == id);
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
