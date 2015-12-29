using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Utilities
{
    public static class Variables
    {
        /*encryptKey for Password */
        public static string EncrptKey = "saigonhobby";

        /*Limit add Item SectionGallery For one product*/
        public static int LimitAddSectionGallery = 3;
    }

    public static class PositionTab
    {
        public const string Feature = "Feature";
        public const string Overview = "Overview";
        public const string Video = "Video";
        public const string Home = "Home";
        public const string Gallery = "Gallery";
        public const string Specs = "Specs";
        public const string Technical = "Technical";
        public const string EventClip = "EventClip";
    }

    public static class RoleUser
    {
        public const string ADMIN = "Administrator";
        public const string CUSTOMER = "customer";
    }

    public static class OrderStatus
    {
        public const string Complete = "Complete";
        public const string Processing = "Processing";
        public const string NotYetApprove = "Not Yet Approve";
        public const string Cancelled = "Cancelled";
    }

    public static class SessionKey
    {
        public const string ROLEMEMBER = "roleMember";
    }

    public enum PositionSection : int
    {
        Feature = 1,
        Overview = 2,
        Video = 3,
        Home = 4,
        Gallery = 5,
        Specs = 6,
        Technical = 7,
        EventClip = 8
    }
    
    public enum BlogPostType : int
    {
        News = 1,
        Video = 2
    }
}
