using Microsoft.AspNetCore.Mvc;

namespace Day_54_01_Exercise_MVC_BS_Site.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Consulting()
        {
            return View();
        }
        public IActionResult Training()
        {
            return View();
        }
    }
}
