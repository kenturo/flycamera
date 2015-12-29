using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class OrderNodeDao : IRepositryBase<Fly_OrderNote>
    {
        public IList<Fly_OrderNote> getAllItems()
        {
            IList<Fly_OrderNote> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_OrderNote>();
                    item = (from it in context.Fly_OrderNote
                            select it).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_OrderNote obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_OrderNote.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_OrderNote obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_OrderNote.FirstOrDefault(x => x.OrderNoteID == obj.OrderNoteID);
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
                    var item = context.Fly_OrderNote.FirstOrDefault(x => x.OrderNoteID == id);
                    if (item != null)
                    {
                        context.Fly_OrderNote.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_OrderNote getItem(int id)
        {
            Fly_OrderNote obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_OrderNote.FirstOrDefault(x => x.OrderNoteID == id);
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