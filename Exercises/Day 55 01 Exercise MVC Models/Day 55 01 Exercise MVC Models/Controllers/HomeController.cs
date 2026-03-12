using Day_55_01_Exercise_MVC_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_55_01_Exercise_MVC_Models.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{Id=1, Name="Rahul",Position="Developer", Salary=5000},
                new Employee{Id=2,Name="Lochan", Position="Designer", Salary=3000},
                new Employee{Id=3,Name="Jerry", Position="Manager",Salary=7000}
            };
            ViewBag.Announcement = "Company meeting at 4 PM";
            ViewData["DepartmentName"] = "IT Department";
            ViewData["ServerStatus"] = false;
            return View(employees);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
