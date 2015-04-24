using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineStoreMVC.Models;

namespace OnlineStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public PartialViewResult _Video()
        {

            ViewBag.Title = "Home Page";
            return PartialView();
        }

        public ActionResult Index()
        {
            var model = new List<UserViewModel>();
            using (var db = new EntityDbContext())
            {
                model = db.Users.OrderByDescending(x=>x.UserID).ToList();
            }

            ViewData["Many"] = (model.Count > 3);

            return View(model);
        }

        public ActionResult _Slider()
        {
          
            return PartialView();
        }

	}
}