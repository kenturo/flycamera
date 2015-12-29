using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.DataAccess;
using Flycamera.ViewModel;
using Flycamera.Model;
using Flycamera.App_Start;
using FlyEntity.Utilities;
using FlyEntity.Repositry;

namespace Flycamera.Controllers.Product
{
    [OutputCache(CacheProfile = "flycameCaches")]
    public class ProductController : BaseController
    {
        readonly PaginationList _paging = new PaginationList();

        readonly IRepositryBase<Fly_Partnership> _repositoryPartner = null;
        readonly IRepositryBase<Fly_Product> _reposProduct = null;
        IRepositryCustomers<Fly_Customer> _repositoryUser = null;
        readonly IRepositryVideos<Fly_Videos> _reposVideo = null;
        readonly IRepositryBase<Fly_Navigation> _repositryNav = null;
        

        readonly ProductsVM _vm = null;

        public ProductController()
        {
            _reposProduct = new ProductDAO();
            _repositoryPartner = new PartnershipDAO();
            _reposVideo = new VideosDAO();
            _repositoryUser = new CustomerDAO();
            _repositryNav = new NavigationDao();

            _vm = new ProductsVM();

            List<Fly_Navigation> listNav = _repositryNav.getAllItems().ToList();
            ViewData[StaticVariable.Navigation] = listNav;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            // get List of Product
            _vm.ProductList = _reposProduct.getAllItems();

            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();

            //ViewData[StaticVariable.PartnerShip] = vm.listPartnerships;
            
            /* return data pagination */
            _paging.TotalItem = _vm.ProductList.Count();
            _paging.PageSize = ConfiguationSite.PageSize;
            _paging.CurrentPage = 1;
            ViewData[StaticVariable.Pagination] = _paging;


            /*return data breadcrumbs */
            List<BreadcrumbsModel> listbreadcrums = new List<BreadcrumbsModel>() {
                new BreadcrumbsModel(){
                    isFirst = true,
                    ControllerName = "Home",
                    ActionName = "Index",
                    isLast = false
                },
                new BreadcrumbsModel(){
                    isFirst = false,
                    ControllerName = ControllerContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString(),
                    ActionName = ControllerContext.Controller.ValueProvider.GetValue("action").RawValue.ToString(),
                    isLast = true
                }
            };
            ViewData[StaticVariable.Breadcrumbs] = listbreadcrums;

            _vm.ProductList = _vm.ProductList.Take(_paging.PageSize).ToList();



            

            return View(_vm);
        }
       
        //
        // GET: /Product/Overview/5

        public ActionResult Overview(int id)
        {
            _vm.Products = _reposProduct.getItem(id);
            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

        //
        // GET: /Product/Feature/5

        public ActionResult Feature(int id)
        {
            _vm.Products = _reposProduct.getItem(id);
            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

        //
        // GET: /Product/Videos/5

        public ActionResult Videos(int id)
        {
            _vm.Products = _reposProduct.getItem(id);
            _vm.ListVideos = _reposVideo.getAllItemsByProductId(id).Where(x => x.Fly_PositionGallery.PositionName_EN.Equals(PositionTab.Video)).ToList();
            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

        public ActionResult Spec(int id)
        {
            _vm.Products = _reposProduct.getItem(id);
            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

        public ActionResult Technical(int id)
        {
            _vm.Products = _reposProduct.getItem(id);
            _vm.ListVideos = _reposVideo.getAllItemsByProductId(id).Where(x => x.Fly_PositionGallery.PositionName_EN.Equals(PositionTab.Technical)).ToList();
            /*get all data Partnership width picture */
            _vm.listPartnerships = _repositoryPartner.getAllItems();
            return View(_vm);
        }

    }
}
