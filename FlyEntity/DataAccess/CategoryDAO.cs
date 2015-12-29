using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
using FlyEntity.Utilities;
namespace FlyEntity.DataAccess
{
    public class CategoryDAO : IRepositryBase<Fly_Category>
    {
        public IList<Fly_Category> getAllItems()
        {
            IList<Fly_Category> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Category>();
                    item = context.Fly_Category.Include("Fly_Category_Discount_Mapping").ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Category obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Category.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Category obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Category.Include("Fly_Category_Discount_Mapping").Include("Fly_CategoryLocalized").Where(x => x.CategoryID == obj.CategoryID).FirstOrDefault();
                    var mappingDiscount = item.Fly_Category_Discount_Mapping.FirstOrDefault();
                    var mappingLocalized = item.Fly_CategoryLocalized.FirstOrDefault();
                    if (item != null)
                    {
                        if (mappingDiscount != null)
                        {
                            var NewValue = obj.Fly_Category_Discount_Mapping.FirstOrDefault();
                            NewValue.CategoryID = (NewValue.CategoryID > 0 || NewValue.CategoryID.Equals(mappingDiscount.CategoryID)) ? mappingDiscount.CategoryID : NewValue.CategoryID;
                            NewValue.DiscountID = (NewValue.DiscountID > 0 || NewValue.DiscountID.Equals(mappingDiscount.DiscountID)) ? mappingDiscount.DiscountID : NewValue.DiscountID;
                            context.Entry(mappingDiscount).CurrentValues.SetValues(NewValue);
                        }
                        if (mappingLocalized != null)
                        {
                            var NewValue = obj.Fly_CategoryLocalized.FirstOrDefault();
                            NewValue.CategoryID = (NewValue.CategoryID == null || NewValue.CategoryID.Equals(mappingLocalized.CategoryID)) ? mappingLocalized.CategoryID : NewValue.CategoryID;
                            NewValue.Name = (NewValue.Name == null || NewValue.Name.Equals(mappingLocalized.Name)) ? mappingLocalized.Name : NewValue.Name;

                            context.Entry(mappingLocalized).CurrentValues.SetValues(NewValue);
                        }
                        
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
                    var item = context.Fly_Category.Where(x => x.CategoryID == id).FirstOrDefault();
                    item.Deleted = true;
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues((Fly_Category)item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Category getItem(int id)
        {
            Fly_Category obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Category.Include("Fly_CategoryLocalized").Include("Fly_Category_Discount_Mapping.Fly_Discount").Where(x => x.CategoryID == id).FirstOrDefault();
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
