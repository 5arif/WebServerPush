using System.Web.Mvc;
using WebServerPush.Filter;

namespace WebServerPush.Controllers
{
    public class HomeController : Controller
    {
        [PushPromise(new[] { "~/Content/bootstrap.css", "~/Content/Site.css" })]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}