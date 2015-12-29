using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using System.Transactions;
using Flycamera.App_Start;
using FlyEntity.Utilities;

namespace Flycamera.Controllers.Payment
{
    public class PaymentController : BaseController
    {
        ShopCartVm _vm;
        readonly IRepositryBase<Fly_Product> _reposProduct = null;
        readonly IRepositryCustomers<Fly_Customer> _repositoryUser = null;
        readonly IRepositryBase<Fly_Country> _repositoryCountry = null;
        readonly IRepositryBase<Fly_ShippingMethod> _repositryShipping = null;
        readonly IRepositryBase<Fly_PaymentMethod> _repositryPaymentMethod = null;
        readonly IRepositryOrder<Fly_Order> _repositryOrder = null;


        public PaymentController()
        {
            _repositryOrder = new OrderDao();
            _repositryShipping = new ShippingMethodDao();
            _repositryPaymentMethod = new PaymentMethodDao();
            _vm = new ShopCartVm();
            _reposProduct = new ProductDAO();
            _repositoryUser = new CustomerDAO();
            _repositoryCountry = new CountryDAO();


            IRepositryBase<Fly_Navigation> repositryNav = new NavigationDao();

            List<Fly_Navigation> listNav = repositryNav.getAllItems().ToList();
            ViewData[StaticVariable.Navigation] = listNav;
        }

        //
        // GET: /Payment/
        public ActionResult Index(int cusId, int productId)
        {
            _vm.Customer = _repositoryUser.getItem(cusId);
            if (_vm.Customer.Fly_CustomerAttribute != null && _vm.Customer.Fly_CustomerAttribute.Count > 0)
            {
                _vm.CustomerAttr =
                    _vm.Customer.Fly_CustomerAttribute.Single(x => x.CustomerId.Equals(_vm.Customer.CustomerID));
            }
            _vm.Products = _reposProduct.getItem(productId);
            _vm.ProductVariant = _vm.Products.Fly_ProductVariant.Single(x => x.ProductID.Equals(_vm.Products.ProductId));
            _vm.Order = new Fly_Order {OrderTotal = _vm.ProductVariant.Price};

            _vm.ListCountryItems = _repositoryCountry.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.CountryID.ToString(),
                    Text = x.Name
                });
            _vm.SelectIndexCountry = 229; // default choose Vietnamese

            _vm.ListShippingItems = _repositryShipping.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.ShippingMethodID.ToString(),
                    Text = x.Name
                });

            _vm.ListPaymentMethodItems = _repositryPaymentMethod.getAllItems().Select(
                x => new SelectListItem
                {
                    Value = x.VisibleName,
                    Text = x.VisibleName
                });


            

            return View(_vm);
        }

//        [HttpPost]
//        public ActionResult Index(int cusId, int productId, ShopCartVm obj)
//        {
//            using (TransactionScope scope = new TransactionScope())
//            {
//                _vm.Order.BillingAddress1 = obj.CustomerAttr.StreetAddress;
//                _vm.Order.BillingEmail = obj.Customer.Email;
//                _vm.Order.BillingFirstName = obj.CustomerAttr.FirstName;
//                _vm.Order.BillingLastName = obj.CustomerAttr.LastName;
//                _vm.Order.BillingPhoneNumber = obj.CustomerAttr.MobilePhone.ToString();
//                _vm.Order.CreatedOn = DateTime.Now;
//                _vm.Order.CustomerID = obj.Customer.CustomerID;
//                _vm.Order.Deleted = false;
//                _vm.Order.ShippingStatusID = 1;
//                //                _vm.Order.ApproveID = 0;
//                _vm.Order.OrderGUID = Guid.NewGuid();
//                _vm.Order.OrderTotal = obj.Order.OrderTotal;
//                _vm.Order.BillingCountryID = obj.SelectIndexCountry;
//                _vm.Order.ShippingMethodID = obj.SelectIndexShipping;
//                _vm.Order.BillingCity = obj.Order.BillingCity;
//                _vm.Order.DeliveryDate = DateTime.ParseExact(obj.DeliveryDate, "dd/MM/yyyy",
//                    CultureInfo.InvariantCulture);
//                _vm.Order.OrderStatus = OrderStatus.NotYetApprove;
//                _vm.Order.PaymentMethodName = obj.SelectNamePaymentMethod;
//
//                _vm.OrderProductVariant.ProductVariantID = obj.ProductVariant.ProductVariantId;
//                _vm.OrderProductVariant.Price = obj.OrderProductVariant.Price;
//                _vm.OrderProductVariant.OrderID = _vm.Order.OrderID;
//                _vm.OrderProductVariant.OrderProductVariantGUID = Guid.NewGuid();
//                _vm.OrderProductVariant.Quantity = obj.OrderProductVariant.Quantity;
//
//                _vm.Order.Fly_OrderProductVariant.Add(_vm.OrderProductVariant);
//
//                _repositryOrder.Add(_vm.Order);
//                scope.Complete();
//                scope.Dispose();
//            }
//            return Json("Checkout Success");
//        }

    }
}
