using System.Web.Mvc;

namespace OnlineStoreMVC.Controllers
{
    public class SearchController : Controller
    {

        [HttpPost]
        public ActionResult Index(string fromcontroller, string searchquery)
        {

            switch (fromcontroller)
            {
                case "User":
                    return RedirectToAction("Index", "User", new { query = searchquery });

            }

            return RedirectToAction("Index", fromcontroller);

        }
        public ActionResult Search(FormCollection collection)
        {
            return RedirectToAction("Search", "CV", new { ID = collection["query"] });
        }


    }
}
