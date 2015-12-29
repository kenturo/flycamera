using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class DiscountDAO: IRepositryBase<Fly_Discount>
    {
        public IList<Fly_Discount> getAllItems()
        {
            IList<Fly_Discount> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Discount>();
                    item = (from it in context.Fly_Discount
                            select it).ToList<Fly_Discount>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Discount obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Discount.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Discount obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Discount.FirstOrDefault(x => x.DiscountID == obj.DiscountID);
                    if (item != null)
                    {
                        obj.StartDate = item.StartDate;
                        obj.EndDate = item.EndDate;
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
                    var item = context.Fly_Discount.FirstOrDefault(x => x.DiscountID == id);
                    if (item != null)
                    {
                        context.Fly_Discount.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Discount getItem(int id)
        {
            Fly_Discount obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Discount.FirstOrDefault(x => x.DiscountID == id);
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
