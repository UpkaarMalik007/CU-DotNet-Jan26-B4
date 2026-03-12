using Microsoft.AspNetCore.Mvc;

namespace Day_54_01_Exercise_MVC_BS_Site.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Software()
        {
            return View();
        }
        public IActionResult Tools()
        {
            return View();
        }
    }
}
