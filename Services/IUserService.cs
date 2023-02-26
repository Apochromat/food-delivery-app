using food_delivery_app.Models.ViewModels;

namespace food_delivery_app.Services; 

public interface IUserService {
    Task Register(RegisterViewModel model);
    Task Login(LoginViewModel model);
    Task Logout();
}