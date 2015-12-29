using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;
namespace Flycamera.ViewModel
{
    public class HomeVM
    {
        public List<Fly_Banner> listBanner { get; set; }
        public List<Fly_Videos> listVideo { get; set; }
        public List<Fly_Partnership> listPartnerships { get; set; }
    }
}