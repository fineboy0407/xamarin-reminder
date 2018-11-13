using System.Web.Mvc;

namespace Reminder.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return PartialView();
        }
    }
}
