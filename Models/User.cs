using System.ComponentModel.DataAnnotations;
using food_delivery_app.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace food_delivery_app.Models;

public class User : IdentityUser<Guid> {
    public String FullName { get; set; } = "";
    public String Password { get; set; } = "";
    public String? Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public ICollection<Rating> RawRating { get; set; }
    public ICollection<Basket> Basket { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<UserRole> Roles { get; set; }
}