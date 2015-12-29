using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;
using Flycamera.ViewModel;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;

namespace Flycamera.Controllers.Accessories
{
    [OutputCache(CacheProfile = "flycameCaches")]
    public class AccessoriesController : BaseController
    {
        readonly IRepositryBase<Fly_Partnership> _repositoryPartner = null;
        readonly IRepositryBase<Fly_Product> _reposProduct = null;
        readonly ProductsVM _vm = null;


        public AccessoriesController()
        {
            _vm = new ProductsVM();
            _reposProduct = new ProductDAO();
            _repositoryPartner = new PartnershipDAO();
            IRepositryBase<Fly_Navigation> repositryNav = new NavigationDao();

            List<Fly_Navigation> listNav = repositryNav.getAllItems().ToList();
            ViewData[StaticVariable.Navigation] = listNav;
        }

        //
        // GET: /Accessories/

        public ActionResult Index(int id)
        {
            _vm.Products = _reposProduct.getItem(id);
            if (_vm.Products.Fly_SectionGallery != null)
                _vm.SectionGalleries = _vm.Products.Fly_SectionGallery.FirstOrDefault(x=>x.ProductID == _vm.Products.ProductId);

            if (_vm.Products.Fly_ProductVariant != null)
                _vm.ProductVariant = _vm.Products.Fly_ProductVariant.FirstOrDefault(x => x.ProductID == _vm.Products.ProductId);

            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

    }
}
