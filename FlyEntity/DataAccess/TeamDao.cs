using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class TeamDao : IRepositryBase<Fly_Team>
    {
        public IList<Fly_Team> getAllItems()
        {
            IList<Fly_Team> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Team>();
                    item = context.Fly_Team.ToList<Fly_Team>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Team obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Team.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Team obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Team.FirstOrDefault(x => x.TeamID == obj.TeamID);
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
                    var item = context.Fly_Team.FirstOrDefault(x => x.TeamID == id);
                    if (item != null)
                    {
                        item.Deleted = true;
                        context.Entry(item).CurrentValues.SetValues((Fly_Team)item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Team getItem(int id)
        {
            Fly_Team obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Team.FirstOrDefault(x => x.TeamID == id);
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
