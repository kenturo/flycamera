using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class OrderVm
    {
        public int Quantity { get; set; }
        public string DeliveryDate { get; set; }
        public int SelectIndexCountry { get; set; }
        public int SelectIndexShipping { get; set; }
        public string SelectNamePaymentMethod { get; set; }
        public Fly_Product Products { get; set; }
        public Fly_Customer Customer { get; set; }
        public Fly_CustomerAttribute CustomerAttr { get; set; }
        public Fly_Order Order { get; set; }
        public List<Fly_Order>  ListOrders { get; set; }
        public Fly_OrderProductVariant OrderProductVariant { get; set; }
        public List<Fly_OrderProductVariant> ListOrderProductVariant { get; set; }
        public Fly_ProductVariant ProductVariant { get; set; }
        public Fly_OrderNote OrderNote { get; set; }
        public Fly_Country Country { get; set; }
        public IEnumerable<SelectListItem> ListCountryItems { get; set; }
        public IEnumerable<SelectListItem> ListShippingItems { get; set; }
        public IEnumerable<SelectListItem> ListPaymentMethodItems { get; set; }

        public OrderVm()
        {
            Order = new Fly_Order();
            ProductVariant = new Fly_ProductVariant();
            Products = new Fly_Product();
            Customer = new Fly_Customer();
            CustomerAttr = new Fly_CustomerAttribute();
            OrderNote = new Fly_OrderNote();
            OrderProductVariant = new Fly_OrderProductVariant();
            Country = new Fly_Country();
        }
    }
}