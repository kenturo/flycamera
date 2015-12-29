using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class CustomerVM
    {
        public List<Fly_Customer> ListCustomer { get; set; }
        public List<Fly_Customer_CustomerRole_Mapping> ListMappingRole { get; set; }
        public List<Fly_CustomerAttribute> ListCustomerAttr { get; set; }
        public List<Fly_CustomerRole> ListCustomerRole { get; set; }
        public List<Fly_CustomerRole_Discount_Mapping> ListMappingDiscount { get; set; }
        public List<Fly_CustomerRole_ProductPrice> ListCustomerProductPrice { get; set; }
        public List<Fly_CustomerSession> ListCustomerSession { get; set; }
        public List<Fly_Picture> ListCustomerAvatar { get; set; }
        public IEnumerable<SelectListItem> PositionCountry { get; set; }


        public Fly_Customer Customer { get; set; }
        public Fly_Customer_CustomerRole_Mapping MappingRole { get; set; }
        public Fly_CustomerAttribute CustomerAttr { get; set; }
        public Fly_CustomerRole CustomerRole { get; set; }
        public Fly_CustomerRole_Discount_Mapping MappingDiscount { get; set; }
        public Fly_CustomerRole_ProductPrice CustomerProductPrice { get; set; }
        public Fly_CustomerSession CustomerSession { get; set; }
        public Fly_Picture CustomerAvatar { get; set; }

        public bool isActive { get; set; }
        public bool isAdmin { get; set; }
        public int selectItem { get; set; }

        public string RoleSelect { get; set; }

        public CustomerVM()
        {
            RoleSelect = "";
        }
        
    }
}