using System.Collections.Generic;
using FlyEntity;

namespace Flycamera.ViewModel
{
    public class TechnicalVm
    {
        public Fly_SectionGallery SectionGalleries { get; set; }
        public Fly_SectionContent SectionContent { get; set; }
        public Fly_Videos Videos { get; set; }


        public IList<Fly_Partnership> ListPartnerships { get; set; }
        public IList<Fly_Videos> ListVideos { get; set; }
        public IList<Fly_SectionGallery> ListSectionGalleries { get; set; }
        public IList<Fly_SectionContent> ListSectionContent { get; set; }

        public TechnicalVm()
        {
            ListVideos = new List<Fly_Videos>();
            ListSectionGalleries = new List<Fly_SectionGallery>();
            ListSectionContent = new List<Fly_SectionContent>();
            ListPartnerships = new List<Fly_Partnership>();
        }
    }
}