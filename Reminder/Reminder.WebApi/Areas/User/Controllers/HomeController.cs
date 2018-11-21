using System.Web.Mvc;

namespace Reminder.WebApi.Areas.User.Controllers
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
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Notes()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateNote()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult NoteDetals(int id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return RedirectToAction("Index");
        }
    }
}
