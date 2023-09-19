using System.Web.Mvc;

namespace Telerik_Project15.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // This action is responsible for displaying the home page
            // You can add your logic here to fetch data or perform other tasks
            // and then return a view to display the home page content
            return View();
        }

        // You can add more action methods as needed for other pages or functionality
        // For example, you might have actions for displaying a profile, settings, etc.
    }
}