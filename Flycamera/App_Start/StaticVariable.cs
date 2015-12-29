using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flycamera.App_Start
{
    public static class StaticVariable
    {
        /*path template partial View */

        //banner
        public static string _BannerTemplate = "~/Views/Shared/_BannerTemplate.cshtml";
        public static string _shareSocial = "~/Views/Shared/_shareSocial.cshtml";
        public static string _VideoHome = "~/Views/Shared/_VideoHome.cshtml";
        public static string _PartnerShipHome = "~/Views/PartnerShip/_PartnerShipHome.cshtml";
        public static string _ServiceStatic = "~/Views/Shared/_ServiceStatic.cshtml";
        public static string _Content = "~/Views/Content/_Content.cshtml";
        public static string _header = "~/Views/Shared/_header.cshtml";
        public static string _Footer = "~/Views/Shared/_Footer.cshtml";
        public static string _Pagination = "~/Views/Shared/_Pagination.cshtml";
        public static string _Breadcrumbs = "~/Views/Shared/_Breadcrumbs.cshtml";

        // product list
        public static string _TabFeature = "~/Views/Product/_TabFeatures.cshtml";
        public static string _ListProducts = "~/Views/Product/_ListProducts.cshtml";
        public static string _ContentProducts = "~/Views/Product/_ContentProducts.cshtml";
        public static string _RotateProducts = "~/Views/Product/_RotateProducts.cshtml";
        public static string _ListTechnical = "~/Views/Product/_ListTechnical.cshtml";
        public static string _AccessoriesInfo = "~/Views/Accessories/_AccessoriesInfo.cshtml";

        // payment
        public static string _ListCart = "~/Views/Payment/_ListCart.cshtml";
        public static string _FormInfomationUser = "~/Views/Payment/_FormInfomationUser.cshtml";

        

        /* Message */
        public static string Msg_Update = "Dữ liệu đang được cập nhật";

        /* Keyword Data */
        public const string PartnerShip = "partnership";
        public const string Pagination = "pagination";
        public const string BannerHome = "bannerhome";
        public const string VideoHome = "videohome";
        public const string Breadcrumbs = "breadcrumbs";
        public const string Navigation = "navigation";

        /*Ajax Link Upload File */
        public const string UploadHandler = "/Api/UploadHandler.ashx";
        public const string PathUploadImage = "/Content/Upload/";


        /* User Login */
        public const string _boxLogin = "~/Views/User/_boxLogin.cshtml";
        public const string _boxRegister = "~/Views/User/_boxRegister.cshtml";
        public const string _popupLogin = "~/Views/User/_popupLogin.cshtml";

        // google map view
        public const string __GoogleMapView = "~/Views/Shared/_GoogleMapView.cshtml";


        //Technical
        public static string _TechnicalGuide = "~/Views/Technical/_TechnicalGuide.cshtml";

    }

    public static class StaticVariableAdministrator
    {
        //common variable
        public static string _header = "~/Areas/Administrator/Views/Shared/_headerAdmin.cshtml";
        public static string _popupChooseProducts = "~/Areas/Administrator/Views/Shared/_PopupChoseProducts.cshtml";
        public static string _popupChooseVideos = "~/Areas/Administrator/Views/Shared/_PopupChoseVideos.cshtml";

        public static string _popupUserLogin = "~/Areas/Administrator/Views/UserLogin/_popupLogin.cshtml";
        public static string _boxLogin = "~/Areas/Administrator/Views/UserLogin/_boxLogin.cshtml";

        public static string _listCustomerRole = "~/Areas/Administrator/Views/Customer/_ListCustomerRole.cshtml";

        public static string _OrderInfo = "~/Areas/Administrator/Views/Order/_OrderInfo.cshtml";
        public static string _ListProductOrder = "~/Areas/Administrator/Views/Order/_ListProductOrder.cshtml";
        public static string _OrderNote = "~/Areas/Administrator/Views/Order/_OrderNote.cshtml";



        public static string PopupReviewContent = "~/Areas/Administrator/Views/ProductGallery/_PopupReviewContent.cshtml";
        

    }

   
}