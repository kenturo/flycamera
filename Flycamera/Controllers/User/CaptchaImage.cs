using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flycamera.App_Start;
using FlyEntity.Utilities;

namespace Flycamera.Controllers.User
{
    public class CaptchaImage:ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            Bitmap bmp = new Bitmap(110, 30);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Navy);
            string randomString = MethodUtilities.GetCaptchaString(6);

            CookiesData.RemoveCookies(context,"codectp");
            CookiesData.setCookies(context, "codectp", randomString, DateTime.Now.AddHours(1));

            //HttpCookie cookie = HttpContext.Current.Request.Cookies["codectp"] ?? new HttpCookie("codectp");
            //cookie.Values["codectp"] = randomString;
            //cookie.Expires = DateTime.Now.AddHours(1);
            //context.HttpContext.Response.Cookies.Add(cookie);
            //context.HttpContext.Session["codectp"] = randomString;

            g.DrawString(randomString, new Font("Courier", 16), new SolidBrush(Color.WhiteSmoke), 2, 2);
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "image/jpeg";
            bmp.Save(response.OutputStream, ImageFormat.Jpeg);
            bmp.Dispose();
        }
    }


}