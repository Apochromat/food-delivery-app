using food_delivery_app.Models;

namespace food_delivery_app.Services; 

public interface IMenuService {
    Task<List<Dish>> GetMenu();
}