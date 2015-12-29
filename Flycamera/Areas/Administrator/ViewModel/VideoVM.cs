using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.DataAccess;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class VideoVM
    {
        /* Attribute */
        public Fly_PositionGallery PositionGalleries { get; set; }
        public Fly_Videos Video { get; set; }
        public Fly_SectionContent SectionContents { get; set; }

        public List<Fly_PositionGallery> ListPositionGalleries{ get; set; }
        public List<Fly_Videos> ListVideo{ get; set; }
        public List<Fly_SectionContent> ListSectionContents{ get; set; }

        public int positionVideo { get; set; }
        public bool isPublish { get; set; }
        public bool isDeleted { get; set; }
        public bool isHome { get; set; }

        public IEnumerable<SelectListItem> PositionGalleriesItemList { get; set; }

        /* DataAccess */
        PositionGalleryDAO posGallery;
        VideosDAO sectionVideo;

        /* contructor */
        public VideoVM()
        {
            ListPositionGalleries = new List<Fly_PositionGallery>();
            ListVideo = new List<Fly_Videos>();
            ListSectionContents = new List<Fly_SectionContent>();
            posGallery = new PositionGalleryDAO();
            sectionVideo = new VideosDAO();
            isPublish = true;
            SectionContents = new Fly_SectionContent();
        }
    }
}