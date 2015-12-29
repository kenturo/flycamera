using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class OrderProductVariantDao : IRepositryOrderProductVariant<Fly_OrderProductVariant>
    {
        public IList<Fly_OrderProductVariant> getAllItems()
        {
            IList<Fly_OrderProductVariant> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_OrderProductVariant>();
                    item = (from it in context.Fly_OrderProductVariant
                            select it).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_OrderProductVariant obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_OrderProductVariant.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_OrderProductVariant obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_OrderProductVariant.FirstOrDefault(x => x.OrderProductVariantID == obj.OrderProductVariantID);
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
                    var item = context.Fly_OrderProductVariant.FirstOrDefault(x => x.OrderProductVariantID == id);
                    if (item != null)
                    {
                        context.Fly_OrderProductVariant.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_OrderProductVariant getItem(int id)
        {
            Fly_OrderProductVariant obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_OrderProductVariant.FirstOrDefault(x => x.OrderProductVariantID == id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public List<Fly_OrderProductVariant> GetItemByOrderId(int orderid)
        {
            List<Fly_OrderProductVariant> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    if (context.Fly_OrderProductVariant != null)
                        item =
                            context.Fly_OrderProductVariant.Where(x => x.OrderID == orderid)
                                .Include("Fly_Order")
                                .Include("Fly_Order.Fly_Country")
                                .Include("Fly_Order.Fly_OrderNote")
                                .Include("Fly_Order.Fly_Customer")
                                .Include("Fly_Order.Fly_ShippingMethod")
                                .Include("Fly_Order.Fly_ShippingStatus")
                                .Include("Fly_ProductVariant")
                                .Include("Fly_ProductVariant.Fly_Product")
                                .ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }
    }
}
