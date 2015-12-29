using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace FlyEntity.DataAccess
{
    public class OrderDao : IRepositryOrder<Fly_Order>
    {
        public IList<Fly_Order> getAllItems()
        {
            IList<Fly_Order> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Order>();
                    item = (from it in context.Fly_Order
                            select it).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Order obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Order.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Order obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Order.FirstOrDefault(x => x.OrderID == obj.OrderID);
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
                    var item = context.Fly_Order.FirstOrDefault(x => x.OrderID == id);
                    if (item != null)
                    {
                        context.Fly_Order.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Order getItem(int id)
        {
            Fly_Order obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Order.FirstOrDefault(x => x.OrderID == id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public List<Fly_Order> GetAllListOrderNotApprove()
        {
            List<Fly_Order> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = (from it in context.Fly_Order
                            where it.ApproveID == null
                            select it)
                            .Include("Fly_Customer")
                            .Include("Fly_ShippingStatus")
                            .Include("Fly_ShippingMethod").ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }


        public bool SetApproveOrder(int orderid, int userId)
        {
            bool isTrue = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Order.Find(orderid);
                    item.ApproveID = userId;
                    item.PaidDate= DateTime.Now;
                    item.OrderStatus = OrderStatus.Processing;
                    item.ShippingStatusID = 2; // Not yet shipped
                    this.Edit(item);
                    isTrue = true;
                }
            }
            catch (DbEntityValidationException ex)
            {
            }
            return isTrue;
        }


        public bool SetCompleteOrder(int orderid)
        {
            bool isTrue = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Order.Find(orderid);
                    item.ShippedDate = DateTime.Now;
                    item.OrderStatus = OrderStatus.Complete;
                    item.ShippingStatusID = 4; // Delivered
                    this.Edit(item);
                    isTrue = true;
                }
            }
            catch (DbEntityValidationException ex)
            {
            }
            return isTrue;
        }

        public bool SetCancelOrder(int orderid)
        {
            bool isTrue = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Order.Find(orderid);
                    item.ShippedDate = DateTime.Now;
                    item.OrderStatus = OrderStatus.Cancelled;
                    item.ShippingStatusID = 1; // Shipping not required
                    this.Edit(item);
                    isTrue = true;
                }
            }
            catch (DbEntityValidationException ex)
            {
            }
            return isTrue;
        }

        public List<Fly_Order> GetAllListOrderByStatus(string status)
        {
            List<Fly_Order> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = context.Fly_Order.Where(x=>x.OrderStatus == status)
                            .Include("Fly_Customer")
                            .Include("Fly_ShippingStatus")
                            .Include("Fly_ShippingMethod").ToList();
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
