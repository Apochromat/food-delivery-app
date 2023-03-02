using food_delivery_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using food_delivery_app.Models.ViewModels;
using food_delivery_app.Services;

namespace food_delivery_app.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menuService;

        public HomeController(ILogger<HomeController> logger, IMenuService menuService) {
            _menuService = menuService;
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> Menu() {
            var menu = new MenuViewModel {
                Dishes = await _menuService.GetMenu()
            };
            return View(menu);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}