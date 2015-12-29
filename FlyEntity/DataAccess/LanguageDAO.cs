using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class LanguageDAO: IRepositryBase<Fly_Language>
    {
        public IList<Fly_Language> getAllItems()
        {
            IList<Fly_Language> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Language>();
                    item = (from it in context.Fly_Language
                            select it).ToList<Fly_Language>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Language obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Language.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Language obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Language.Where(x => x.LanguageId == obj.LanguageId).FirstOrDefault();
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
                    var item = context.Fly_Language.Where(x => x.LanguageId == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_Language.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Language getItem(int id)
        {
            Fly_Language obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Language.Where(x => x.LanguageId == id).FirstOrDefault();
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
