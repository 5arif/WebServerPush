using System;
using System.Linq;
using System.Web.Mvc;
using WebServerPush.Helper;

namespace WebServerPush.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class PushPromiseAttribute : FilterAttribute, IActionFilter
    {
        string[] localPath;
        string revNum;
        
        public PushPromiseAttribute(string[] path)
        {
            localPath = path;
            revNum = AppsHelper.GetRevNumber();
        }
        
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var urlHelp = new UrlHelper(filterContext.RequestContext);
            localPath.ToList().ForEach(e =>
            {
                var path = urlHelp.Content(e);
                if (!AppsHelper.IsDebug)
                {
                    path += "?rev=" + revNum;
                }

                filterContext.RequestContext.HttpContext.Response.PushPromise(path);
            });
        }
    }
}