using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class ManufacturerVM
    {
        public Fly_Manufacturer Manufacturer { get; set; }
        public Fly_ManufacturerLocalized ManufacturerLocalized { get; set; }

        public List<Fly_Manufacturer> ListManufacturer { get; set; }
        public List<Fly_ManufacturerLocalized> ListManufacturerLocalized { get; set; }

        public bool isPubish { get; set; }
        public bool isDelete { get; set; }

        public ManufacturerVM()
        {
            Manufacturer = new Fly_Manufacturer();
            ManufacturerLocalized = new Fly_ManufacturerLocalized();
            ListManufacturer = new List<Fly_Manufacturer>();
            ListManufacturerLocalized = new List<Fly_ManufacturerLocalized>();

            isPubish = true;
            isDelete = false;
        }
    }
}