using food_delivery_app.Models;
using Microsoft.AspNetCore.Identity;

namespace food_delivery_app.Services; 

public class MenuService : IMenuService {
    private readonly UserManager<User> _userManager;
    private readonly ILogger<MenuService> _logger;
    private readonly ApplicationDbContext _context;

    public MenuService(UserManager<User> userManager,
        SignInManager<User> signInManager, ILogger<MenuService> logger, ApplicationDbContext context) {
        _userManager = userManager;
        _logger = logger;
        _context = context;
    }

    public async Task<List<Dish>> GetMenu() {
        return _context.Dishes.Select(x => x).ToList();
    }
}