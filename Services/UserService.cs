using System.Security.Claims;
using food_delivery_app.Models;
using food_delivery_app.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace food_delivery_app.Services;

public class UserService : IUserService {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<UserService> _logger;

    public UserService(UserManager<User> userManager,
        SignInManager<User> signInManager, ILogger<UserService> logger) {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    public async Task Register(RegisterViewModel model) {
        var user = new User {
            Email = model.Email,
            UserName = model.Email,
            BirthDate = model.BirthDate,
            PhoneNumber = model.Phone,
            FullName = model.Name,
            Gender = model.Gender,
            Address = model.Address
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded) {
            _logger.LogInformation("Successful registration");
            await _signInManager.SignInAsync(user, false);
            return;
        }

        var errors = string.Join(", ", result.Errors.Select(x => x.Description));
        throw new ArgumentException(errors);
    }

    public async Task Login(LoginViewModel model) {
        var user = await _userManager.FindByNameAsync(model.Email);
        if (user == null) {
            throw new KeyNotFoundException($"User with email = {model.Email} does not found");
        }

        var claims = new List<Claim> {
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        if (user.Roles?.Any() == true) {
            var roles = user.Roles.Select(x => x.Role).ToList();
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
        }

        var authProperties = new AuthenticationProperties {
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2),
            IsPersistent = true
        };
        
        await _signInManager.SignInWithClaimsAsync(user, authProperties, claims);
    }

    public async Task Logout() {
        await _signInManager.SignOutAsync();
    }
}