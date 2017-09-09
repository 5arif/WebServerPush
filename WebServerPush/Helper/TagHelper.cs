using System.Linq;
using System.Web.Mvc;

namespace WebServerPush.Helper
{
    public  static class TagHelper
    {
        public static MvcHtmlString Style(this HtmlHelper helper, string[] asset)
        {
            var tpl = "";
            asset.ToList().ForEach(e =>
            {
                var path = AppsHelper.GetPath(e);
                var url = GetReleasePath(path, "css");

                var style = $"<link rel=\"stylesheet\" href=\"{url}\"/>";
                tpl += style;
            });

            return MvcHtmlString.Create(tpl);
        }

        private static string GetMinifyPath(string path, string fileExt)
        {
            var minExt = ".min." + fileExt;
            if (!path.Contains(minExt))
            {
                var nonExt = path.Substring(0, path.Length - fileExt.Length);
                var withExt = nonExt + "min." + fileExt;
                path = withExt;
            }

            return path;
        }

        private static string GetReleasePath(string path, string fileExt)
        {
            var revPath = GetMinifyPath(path, fileExt);
            if (!AppsHelper.IsDebug)
            {
                var revNumber = AppsHelper.GetRevNumber();
                revPath += "?rev=" + revNumber;
            }

            return revPath;
        }
    }
}