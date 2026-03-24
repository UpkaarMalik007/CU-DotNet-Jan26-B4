using Microsoft.AspNetCore.Mvc;
using GlobalMart.Services;
using GlobalMart.Models;
using GlobalMart.ViewModel;

namespace GlobalMart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IPricingService _pricingService;

        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Wireless Mouse", Price = 29.99m },
            new Product { Id = 3, Name = "Mechanical Keyboard", Price = 79.99m },
            new Product { Id = 4, Name = "USB-C Hub", Price = 49.99m },
            new Product { Id = 5, Name = "Monitor Stand", Price = 39.99m }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = products.First(p => p.Id == productId);

            CartController.cart.Add(new CartViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                OriginalPrice = product.Price,
                FinalPrice = product.Price,
                PromoCode = "None"
            });

            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("Index");
        }
    }
}
