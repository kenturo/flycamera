using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class NavigationVm
    {
        public Fly_Navigation Navigation { get; set; }
        public bool Publish { get; set; }
        public bool Deleted { get; set; }
        public string SubProducts { get; set; }


        public NavigationVm()
        {
            Navigation = new  Fly_Navigation();
            Publish = true;
            Deleted = false;
        }
    }
}