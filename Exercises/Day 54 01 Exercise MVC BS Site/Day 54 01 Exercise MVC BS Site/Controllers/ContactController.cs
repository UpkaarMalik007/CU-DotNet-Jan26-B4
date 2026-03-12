using Microsoft.AspNetCore.Mvc;

namespace Day_54_01_Exercise_MVC_BS_Site.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
