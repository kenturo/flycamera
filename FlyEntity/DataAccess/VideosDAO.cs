using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace FlyEntity.DataAccess
{
    public class VideosDAO : IRepositryVideos<Fly_Videos>
    {


        public IList<Fly_Videos> getAllItems()
        {
            IList<Fly_Videos> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Videos>();
                    item = context.Fly_Videos
                        .Include("Fly_Picture")
                        .Include("Fly_Customer")
                        .Include("Fly_Product")
                        .Include("Fly_PositionGallery")
                        .Include("Fly_SectionContent")
                        .ToList<Fly_Videos>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Videos obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Videos.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Videos obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Videos.FirstOrDefault(x => x.VideosID == obj.VideosID);
                    var sectionContent = context.Fly_SectionContent.FirstOrDefault(x => x.SectionContentID == obj.Fly_SectionContent.SectionContentID);
                    if (item != null)
                    {
                        if (sectionContent != null)
                            context.Entry(sectionContent).CurrentValues.SetValues(obj.Fly_SectionContent);
                        context.Entry(item).CurrentValues.SetValues(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
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
                    var item = context.Fly_Videos.FirstOrDefault(x => x.VideosID == id);
                    item.Deleted = true;
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues((Fly_Videos)item);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Fly_Videos getItem(int id)
        {
            Fly_Videos obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Videos
                        .Include("Fly_Picture")
                        .Include("Fly_Customer")
                        .Include("Fly_Product")
                        .Include("Fly_PositionGallery")
                        .Include("Fly_SectionContent").FirstOrDefault(x => x.VideosID == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public IList<Fly_Videos> getAllItemsByHome()
        {
            IList<Fly_Videos> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Videos>();
                    item = context.Fly_Videos
                        .Include("Fly_Picture")
                        .Include("Fly_Customer")
                        .Include("Fly_Product")
                        .Include("Fly_PositionGallery")
                        .Include("Fly_SectionContent")
                        .Where(x=>x.isShowHome == true && x.Published == true)
                        .ToList<Fly_Videos>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }


        public IList<Fly_Videos> getAllItemsByProductId(int id)
        {
            IList<Fly_Videos> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Videos>();
                    item = context.Fly_Videos
                        .Include("Fly_Picture")
                        .Include("Fly_Customer")
                        .Include("Fly_Product")
                        .Include("Fly_PositionGallery")
                        .Include("Fly_SectionContent")
                        .Where(x => x.ProductId == id && x.Published == true)
                        .ToList<Fly_Videos>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }


        public IList<Fly_Videos> getAllItemsByTechnical()
        {
            IList<Fly_Videos> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Videos>();
                    item = context.Fly_Videos
                        .Include("Fly_Picture")
                        .Include("Fly_Customer")
                        .Include("Fly_Product")
                        .Include("Fly_PositionGallery")
                        .Include("Fly_SectionContent")
                        .Where(x=>x.ProductId == null && x.Published == true)
                        .ToList<Fly_Videos>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }


        public IList<Fly_Videos> getAllItemsByType(string type)
        {
            IList<Fly_Videos> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Videos>();
                    item = context.Fly_Videos
                        .Include("Fly_Picture")
                        .Include("Fly_Customer")
                        .Include("Fly_Product")
                        .Include("Fly_PositionGallery")
                        .Include("Fly_SectionContent")
                        .Where(x => x.Published == true && x.Fly_PositionGallery.PositionName_EN.Equals(type))
                        .ToList<Fly_Videos>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }
    }
}
