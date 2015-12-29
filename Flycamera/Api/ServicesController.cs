using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services.Description;
using FlyEntity;
using FlyEntity.DataAccess;
using Newtonsoft.Json;
using Flycamera.ViewModel;
using Flycamera.App_Start;
using FlyEntity.Repositry;
using FlyEntity.Utilities;
using Flycamera.Areas.Administrator.ViewModel;

namespace Flycamera.Controllers.API
{
    public class ServicesController : Controller
    {

        [HttpGet]
        public JsonResult GetPicture()
        {
            IRepositryPicture<Fly_Picture> picdao = new PictureDAO(); 
            try
            {
                List<Fly_Picture> pic = picdao.getAllItems().ToList();
                return Json(pic.Select(x => new 
                {
                    x.OriginalURL,
                    x.PictureID
                }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [HttpPost]
        public ActionResult UploadImage(string imgLink)
        {
            IRepositryPicture<Fly_Picture> picdao = new PictureDAO();
            int idpic = 0;
            Fly_Picture objPicture = picdao.getItemByUrl(imgLink);
            if (objPicture != null)
            {
                idpic = objPicture.PictureID;
            }
            else
            {
                objPicture = new Fly_Picture();
                objPicture.OriginalURL = imgLink;
                objPicture.MimeType = imgLink.Substring(imgLink.Length - 3);
                objPicture.IsNew = true;
                picdao.Add(objPicture);
                idpic = objPicture.PictureID;
            }
            return Json(new { id = idpic });
        }

        public JsonResult getListProduct(int take, int skip)
        {
            IRepositryBase<Fly_Product> repository = new ProductDAO();
            try
            {
                List<ProductsVM> ProductList = new List<ProductsVM>();
                var listItem = repository.getAllItems().Skip(skip).Take(take);

                foreach (var item in listItem.ToList())
                {
                    if (!item.Deleted.GetValueOrDefault())
                    {
                        ProductList.Add(new ProductsVM()
                        {
                            ProductName = item.Name,
                            ProductID = item.ProductId,
                            Price = item.Fly_ProductVariant.FirstOrDefault().Price,
                            PriceAdmin = item.Fly_ProductVariant.FirstOrDefault().AdminPrice,
                            isCallForFrice = item.Fly_ProductVariant.FirstOrDefault().CallForPrice,
                            ImageLink = item.Fly_ProductPicture.FirstOrDefault().Fly_Picture.OriginalURL,
                            isHot = item.Fly_ProductVariant.FirstOrDefault().isHot,
                            isGift = item.Fly_ProductVariant.FirstOrDefault().isGift,
                            isNew = item.Fly_ProductVariant.FirstOrDefault().isNew
                        });
                    }
                }

                return Json(ProductList.Select(x => new
                {
                    x.ProductID,
                    x.ProductName,
                    x.Price,
                    x.isCallForFrice,
                    x.ImageLink,
                    x.isHot,
                    x.isGift,
                    x.isNew,
                    x.PriceAdmin
                }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [HttpPost]
        public ActionResult GetListProductForChoose(int pagesize = 100)
        {
            IRepositryBase<Fly_Product> repository = new ProductDAO();
            var data = from p in repository.getAllItems()
                       where p.Published == true
                       select new { ProductName = p.Name, ShortContent = p.ShortDescription, ImageLink = p.Fly_ProductPicture.FirstOrDefault().Fly_Picture.OriginalURL, Id = p.ProductId, Accessory = p.isAccessories };

            return Json(new { result = data.Take(pagesize) });
        }

        [HttpPost]
        public ActionResult GetListVideoForChoose(int pagesize = 100)
        {
            IRepositryVideos<Fly_Videos> repository = new VideosDAO();
            var listVideo = repository.getAllItems().ToList().Select(x => new { Title = x.VideosTitle, VideoLink = x.VideosLink, ImageLink = x.Fly_Picture.OriginalURL });

            return Json(new { result = listVideo.Take(pagesize) });
        }

        [HttpGet]
        public JsonResult GetFeatureTab(string type)
        {
            ProductGalleryVM vm = new ProductGalleryVM();
            IRepositrySectionContent<Fly_SectionContent> _repoSectionContent = new SectionContentDAO();

            try
            {
                vm.ListSectionContents = _repoSectionContent.getAllItems().Where(x => x.Fly_PositionGallery.PositionName_EN.Equals(type)).ToList();
                return Json(vm.ListSectionContents.Select(x => new
                {
                    x.ProductID,
                    x.Fly_Product.Name,
                    x.Fly_PositionGallery.PositionName,
                    x.FullDescription,
                    x.FullDescription_EN
                }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpGet]
        public JsonResult GetListRelateProduct(int id)
        {
            IRepositryBase<Fly_Product> repository = new ProductDAO();
            IRepositryRelateProducts<Fly_RelatedProduct> _repoRelatedProduct = new RelatedProductDAO();
            try
            {

                List<Fly_RelatedProduct> listRelate = _repoRelatedProduct.getAllItemsByProductID(id).ToList();
                List<Fly_Product> listProduct = new List<Fly_Product>();
                foreach (var item in listRelate)
                {
                    listProduct.Add(repository.getItem(item.ProductID2.GetValueOrDefault()));
                }


                var rs = from i in listRelate
                         join a in listProduct
                         on i.ProductID2 equals a.ProductId
                         select new
                         {
                             i.RelatedProductID,
                             a.Name,
                             i.ProductID1,
                             i.ProductID2,
                             a.Fly_ProductPicture.Where(y => y.ProductID == a.ProductId).FirstOrDefault().Fly_Picture.OriginalURL
                         };

                return Json(rs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpPost]
        public JsonResult RemoveRelateProduct(int id)
        {
            IRepositryRelateProducts<Fly_RelatedProduct> repoRelatedProduct = new RelatedProductDAO();
            bool result = false;
            try
            {
                repoRelatedProduct.Delete(id);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return Json(new { result = result });
        }

        [HttpPost]
        public ActionResult GetListAccessoriesForChoose(int pagesize = 100)
        {
            IRepositryBase<Fly_Product> repository = new ProductDAO();
            var data = from p in repository.getAllItems()
                       where p.Published == true && p.isAccessories == true
                       select new { ProductName = p.Name, ShortContent = p.ShortDescription, ImageLink = p.Fly_ProductPicture.FirstOrDefault().Fly_Picture.OriginalURL, Id = p.ProductId };

            return Json(new { result = data.Take(pagesize) });
        }

        [HttpGet]
        public JsonResult isExistAccount(string userName)
        {
            bool isFlag = false;
            IRepositryCustomers<Fly_Customer> repositoryUser = new CustomerDAO();
            try
            {
                isFlag = repositoryUser.isExistAccount(userName.Trim());
                return Json(isFlag, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpGet]
        public JsonResult isExistEmail(string email)
        {
            bool isFlag = false;
            IRepositryCustomers<Fly_Customer> repositoryUser = new CustomerDAO();
            try
            {
                isFlag = repositoryUser.isExistEmails(email.Trim());
                return Json(isFlag, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpPost]
        public JsonResult RemoveMappingRole(int mappingRoleId, int customerId)
        {
            IRepositryMappingRole<Fly_Customer_CustomerRole_Mapping> repositryMapping = new CustomerMappingRoleDao(); ;
            bool isFlag = false;
            try
            {
                isFlag = repositryMapping.RemoveItemById(mappingRoleId, customerId);
                return Json(isFlag, JsonRequestBehavior.DenyGet);
            }
             catch (Exception)
            {
                isFlag = false;
            }

            return Json(new { result = isFlag });
        }

        [HttpPost]
        public JsonResult UpdateInformationOrder(string orderId, string userId, string type)
        {
            IRepositryOrder<Fly_Order> repositryOrder = new OrderDao();
            IRepositryBase<Fly_OrderNote> repositryOrderNote = new OrderNodeDao();
            bool isTrue = false;
            Fly_OrderNote obj = null;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    switch (type)
                    {
                        //approve order
                        case "1":
                            isTrue = repositryOrder.SetApproveOrder(int.Parse(orderId), int.Parse(userId));
                            obj = new Fly_OrderNote
                            {
                                OrderID = int.Parse(orderId),
                                Note = "Order status has been changed to Processing",
                                DisplayToCustomer = false,
                                CreatedOn = DateTime.Now
                            };
                            break;

                        // update order status Complete
                        case "2":
                            isTrue = repositryOrder.SetCompleteOrder(int.Parse(orderId));
                            obj = new Fly_OrderNote
                            {
                                OrderID = int.Parse(orderId),
                                Note = "Order status has been changed to Complete",
                                DisplayToCustomer = true,
                                CreatedOn = DateTime.Now
                            };
                            break;

                        // update order status Cancel
                        case "3":
                            isTrue = repositryOrder.SetCompleteOrder(int.Parse(orderId));
                            obj = new Fly_OrderNote
                            {
                                OrderID = int.Parse(orderId),
                                Note = "Order status has been changed to Cancel",
                                DisplayToCustomer = true,
                                CreatedOn = DateTime.Now
                            };
                            break;
                    }
                    repositryOrderNote.Add(obj);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                isTrue = false;
            }
            return Json(new { result = isTrue });
        }

        [HttpGet]
        public JsonResult SearchOrderStatus(string status)
        {
            IRepositryOrder<Fly_Order> repositryOrder = new OrderDao();
            List<Fly_Order> listobjOrders;
            try
            {
                listobjOrders = repositryOrder.GetAllListOrderByStatus(status);
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message, Message = ex.Message });

            }
            var rs = listobjOrders.Select(x => new
            {
                orderid = x.OrderID,
                ordertotal = x.OrderTotal,
                orderstatus = x.OrderStatus,
                paymentmethod = x.PaymentMethodName,
                shippingmethod = x.Fly_ShippingMethod.Name,
                shippingstatus = x.Fly_ShippingStatus.Name,
                customer = x.Fly_Customer.Email,
                createdon = x.CreatedOn.GetValueOrDefault().ToString("dd/mm/yyy"),
            });
            return Json(new {result = rs}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult OrderItem(ShopCartVm obj)
        {
            ShopCartVm _vm = new ShopCartVm();
            IRepositryOrder<Fly_Order> repositryOrder = new OrderDao();
            bool isSuccess = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _vm.Order.BillingAddress1 = obj.CustomerAttr.StreetAddress;
                    _vm.Order.BillingEmail = obj.Customer.Email;
                    _vm.Order.BillingFirstName = obj.CustomerAttr.FirstName;
                    _vm.Order.BillingLastName = obj.CustomerAttr.LastName;
                    _vm.Order.BillingPhoneNumber = obj.CustomerAttr.MobilePhone.ToString();
                    _vm.Order.CreatedOn = DateTime.Now;
                    _vm.Order.CustomerID = obj.Customer.CustomerID;
                    _vm.Order.Deleted = false;
                    _vm.Order.ShippingStatusID = 1;
                    _vm.Order.OrderGUID = Guid.NewGuid();
                    _vm.Order.OrderTotal = obj.Order.OrderTotal;
                    _vm.Order.BillingCountryID = obj.SelectIndexCountry;
                    _vm.Order.ShippingMethodID = obj.SelectIndexShipping;
                    _vm.Order.BillingCity = obj.Order.BillingCity;
                    _vm.Order.DeliveryDate = DateTime.ParseExact(obj.DeliveryDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                    _vm.Order.OrderStatus = OrderStatus.NotYetApprove;
                    _vm.Order.PaymentMethodName = obj.SelectNamePaymentMethod;

                    //
                    _vm.OrderProductVariant.ProductVariantID = obj.ProductVariant.ProductVariantId;
                    _vm.OrderProductVariant.Price = obj.OrderProductVariant.Price;
                    _vm.OrderProductVariant.OrderID = _vm.Order.OrderID;
                    _vm.OrderProductVariant.OrderProductVariantGUID = Guid.NewGuid();
                    _vm.OrderProductVariant.Quantity = obj.OrderProductVariant.Quantity;
                    _vm.Order.Fly_OrderProductVariant.Add(_vm.OrderProductVariant);

                    // 
                    _vm.OrderNote.OrderID = _vm.Order.OrderID;
                    _vm.OrderNote.Note = "Order status has been changed to Not Yet Approve";
                    _vm.OrderNote.DisplayToCustomer = false;
                    _vm.OrderNote.CreatedOn = DateTime.Now;
                    _vm.Order.Fly_OrderNote.Add(_vm.OrderNote);

                    //
                    repositryOrder.Add(_vm.Order);



                    scope.Complete();
                    scope.Dispose();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return Json(new { rs = isSuccess });
        }


        [HttpPost]
        public ActionResult Login(string uname, string pwd)
        {
            bool flag = false;
            IRepositryCustomers<Fly_Customer> repositoryUser = new CustomerDAO();
            try
            {
                Fly_Customer objUser = repositoryUser.SignIn(uname, pwd);
                flag = (objUser != null);
                if (flag)
                {
                    FormsAuthentication.SetAuthCookie(uname, true);
                    Session["idxu"] = objUser.CustomerID;
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return Json(flag, JsonRequestBehavior.DenyGet);
        }


        [HttpGet]
        public ActionResult GetListPartnership()
        {
            List<Fly_Partnership> listItem = new List<Fly_Partnership>();
            IRepositryBase<Fly_Partnership> repositoryPartner = new PartnershipDAO();
            try
            {
                listItem = repositoryPartner.getAllItems().ToList();
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message, Message = ex.InnerException.Message });

            }
            var rs = listItem.Where(x=>x.Published.GetValueOrDefault() == true).Select(x => new
            {
                id = x.PartnershipID,
                link = x.PartnershipLink,
                title = x.PartnershipTitle,
                imglink = x.Fly_Picture.OriginalURL
            });
            return Json(new { result = rs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetListEventVideo()
        {
            IRepositryVideos<Fly_Videos> repository = new VideosDAO();
            var listItem = new List<Fly_Videos>();
            try
            {
                listItem = repository.getAllItemsByType(PositionTab.EventClip).ToList();
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message, Message = ex.InnerException.Message });
            }

            var rs = listItem.Select(x => new
            {
                id = x.VideosID,
                title = x.VideosTitle,
                link = x.VideosLink,
                imglink = x.Fly_Picture.OriginalURL
            });
            return Json(new { result = rs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetListBlogPost()
        {
            IRepositryBase<Fly_BlogPost> repository = new BlogPostDAO();
            BlogPostVm vm = new  BlogPostVm();
            try
            {
                vm.ListBlogPost = repository.getAllItems().Where(x=>x.Published == true).ToList();
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message, Message = ex.Message });
            }

            var rs = vm.ListBlogPost.Select(x => new
            {
                id = x.BlogPostID,
                title = x.BlogPostTitle,
                date = x.CreatedOn.GetValueOrDefault().ToString("dd-MM-yy"),
                imglink = x.ImageUrl,
                shortcontent = x.BlogPostShortContent,
                typeblog = x.Fly_BlogPostType.Title,
                videolink = x.VideoLink
            });
            return Json(new { result = rs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetailBlogPost(int id)
        {
            IRepositryBase<Fly_BlogPost> repository = new BlogPostDAO();
            BlogPostVm vm = new BlogPostVm();
            try
            {
                vm.Blogpost = repository.getItem(id);
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message, Message = ex.InnerException.Message });
            }

            if (vm.Blogpost != null && vm.Blogpost.Published != true)
            {
                vm.Blogpost = null;
            }
            if (vm.Blogpost != null)
            {
                var rs = new
                {
                    id = vm.Blogpost.BlogPostID,
                    description = vm.Blogpost.BlogPostBody,
                    title = vm.Blogpost.BlogPostTitle,
                    date = vm.Blogpost.CreatedOn.GetValueOrDefault().ToString("dd-MM-yy"),
                    imglink = vm.Blogpost.ImageUrl,
                    shortcontent = vm.Blogpost.BlogPostShortContent,
                    videolink = vm.Blogpost.VideoLink
                };
                return Json(new {result = rs}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = "null" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetListTeam()
        {
            IRepositryBase<Fly_Team> repository = new TeamDao();
            var vmTeam = new List<Fly_Team>();

            try
            {
                vmTeam = repository.getAllItems().Where(x => x.Published == true).ToList();
            }
            catch (Exception ex)
            {

                return Json(new { result = ex.Message, Message = ex.Message });
            }

            var rs = vmTeam.Select(x => new
            {
                id = x.TeamID,
                fullname = x.FullName,
                tagline = x.TagLine,
                description = x.Description,
                avatar = x.AvatarURL,
                facebook = x.Facebook,
                google = x.Google,
                twitter = x.Twitter
            });
            return Json(new { result = rs }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetListBannerServices()
        {
            IRepositryBase<Fly_Banner> repository = new BannerDAO();
            BannerModel vm = new BannerModel();
            var rs = new object();
            try
            {
                vm.listBanner = repository.getAllItems().Where(x => x.Published == true && x.Fly_BannerType.BannerTypeTitle.Equals("Banner Service")).ToList();

                rs = vm.listBanner.Select(x => new
                {
                    id = x.BannerID,
                    title = x.BannerTitle,
                    link = x.BannerLink,
                    shortcontent = x.BannerShortContent,
                    imglink = x.Fly_Picture.OriginalURL,
                    type = x.Fly_BannerType.BannerTypeTitle
                });
            }
            catch (Exception ex)
            {

                return Json(new { result = ex.Message, Message = ex.Message });
            }
            return Json(new { result = rs }, JsonRequestBehavior.AllowGet);
        }
    }
}
