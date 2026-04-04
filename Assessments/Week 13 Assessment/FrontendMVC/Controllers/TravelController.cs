using FrontendMVC.Services;
using FrontendMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AddDestinationViewModel model)
        {
            await _service.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            var model = new UpdateDestinationViewModel
            {
                CityName = data.CityName,
                Country = data.Country,
                Description = data.Description,
                Rating = data.Rating
            };
            ViewBag.Id = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateDestinationViewModel model)
        {
            await _service.UpdateAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
