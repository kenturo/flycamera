using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FlyEntity.Utilities;

namespace Flycamera.App_Start
{
    public static class Helper
    {
        /* Extension Image */
        public static MvcHtmlString Image(this HtmlHelper helper, string name, string className)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", name);
            img.MergeAttribute("class", className);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        } 

        public static MvcHtmlString Image(this HtmlHelper helper, string name, string className, string alt) 
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", name);
            img.MergeAttribute("class", className);
            img.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string name)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", name);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string name, string className, string width, string height, string alt)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", name);
            img.MergeAttribute("class", className);
            img.MergeAttribute("width", width);
            img.MergeAttribute("height", height);
            img.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string className, string width, string height, string alt)
        {
            Func<TModel, TProperty> method = expression.Compile();
            TagBuilder img = new TagBuilder("img");
            string src = "/Content/images/sprite/no-image.png";
            try
            {
                src = method(htmlHelper.ViewData.Model).ToString();
            }
            catch (Exception)
            {
                
            }
            img.MergeAttribute("src", src);
            img.MergeAttribute("class", className);
            img.MergeAttribute("width", width);
            img.MergeAttribute("height", height);
            img.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string className)
        {
            Func<TModel, TProperty> method = expression.Compile();
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", (htmlHelper.ViewData.Count > 0) ? method(htmlHelper.ViewData.Model).ToString() : "");
            img.MergeAttribute("class", className);
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

        public static string SeoUrl(this UrlHelper helper, string urltoEncode)
        {
            urltoEncode = (urltoEncode ?? "").Trim().ToLower();

            StringBuilder url = new StringBuilder();

            foreach (char ch in urltoEncode)
            {
                switch (ch)
                {
                    case ' ':
                        url.Append('-');
                        break;
                    case '&':
                        url.Append("and");
                        break;
                    case '\'':
                        break;
                    default:
                        if ((ch >= '0' && ch <= '9') ||
                            (ch >= 'a' && ch <= 'z'))
                        {
                            url.Append(ch);
                        }
                        else
                        {
                            url.Append('-');
                        }
                        break;
                }
            }

            return url.ToString();
        }
    }

    public static class CookiesData
    {
        public static void setCookies(ControllerContext context,string key,string value,DateTime expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key] ?? new HttpCookie(key);
            cookie.Values[key] = value;
            cookie.Expires = expires;
            //cookie.Secure = true;
            context.HttpContext.Response.Cookies.Add(cookie);
            context.HttpContext.Session[key] = value;
        }

        public static void RemoveCookies(ControllerContext context,string key)
        {
            context.HttpContext.Response.Cookies.Remove(key);
        }
    }

}