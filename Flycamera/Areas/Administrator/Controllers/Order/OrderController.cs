using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.Areas.Administrator.ViewModel;
using Flycamera.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace Flycamera.Areas.Administrator.Controllers.Order
{
    [Authorize(Roles = RoleUser.ADMIN)]
    public class OrderController : Controller
    {
        OrderVm _vm;
        readonly IRepositryBase<Fly_Product> _reposProduct = null;
        readonly IRepositryCustomers<Fly_Customer> _repositoryUser = null;
        readonly IRepositryBase<Fly_Country> _repositoryCountry = null;
        readonly IRepositryBase<Fly_ShippingMethod> _repositryShipping = null;
        readonly IRepositryBase<Fly_PaymentMethod> _repositryPaymentMethod = null;
        readonly IRepositryOrder<Fly_Order> _repositryOrder = null;
        readonly IRepositryOrderProductVariant<Fly_OrderProductVariant> _repositryOrderProductVariant = null;


        public OrderController()
        {
            _repositryOrder = new OrderDao();
            _repositryShipping = new ShippingMethodDao();
            _repositryPaymentMethod = new PaymentMethodDao();
            _vm = new OrderVm();
            _reposProduct = new ProductDAO();
            _repositoryUser = new CustomerDAO();
            _repositoryCountry = new CountryDAO();
            _repositryOrderProductVariant = new OrderProductVariantDao();
        }
        //
        // GET: /Administrator/Order/

        public ActionResult Index()
        {
            _vm.ListOrders = _repositryOrder.GetAllListOrderNotApprove().ToList();
            return View(_vm);
        }

        public ActionResult Detail(int id)
        {
            _vm.ListOrderProductVariant = _repositryOrderProductVariant.GetItemByOrderId(id).ToList();
            var order = _vm.ListOrderProductVariant.FirstOrDefault(x=>x.OrderID == id);
            if (order != null)
                _vm.Order = order.Fly_Order;

            return View(_vm);
        }

    }
}
