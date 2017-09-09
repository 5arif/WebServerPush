using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebServerPush.Helper
{
    public static class AppsHelper
    {
        public static string GetRevNumber()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
        }
        
        public static string GetRevPath(string path)
        {
            var url = GetPath(path);
            var revNum = GetRevNumber();

            url += "?rev=" + revNum;
            return url;
        }

        public static string GetPath(string path)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext).Content(path);
            return url;
        }

        public static bool IsDebug
        {
            get
            {
                var debug = false;
#if DEBUG
                debug = true;
#endif

                return debug;
            }
        }

    }
}