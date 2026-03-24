using GlobalMart.Models;
using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;
using GlobalMart.ViewModel;
namespace GlobalMart.Controllers
{
    public class CartController : Controller
    {

        private readonly IPricingService _pricingService;

        // ✅ Static cart list (replaces CartStore)
        public static List<CartViewModel> cart = new List<CartViewModel>();

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult ApplyPromo(string promoCode)
        {
            foreach (var item in cart)
            {
                item.FinalPrice = _pricingService.CalculatePrice(item.OriginalPrice, promoCode);
                item.PromoCode = string.IsNullOrWhiteSpace(promoCode) ? "None" : promoCode;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Clear()
        {
            cart.Clear();
            return RedirectToAction("Index");
        }
    }
}
