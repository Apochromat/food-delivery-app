using System.ComponentModel.DataAnnotations;
using food_delivery_app.Models.Enums;

namespace food_delivery_app.Models;

public class Dish {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public String Name { get; set; } = "";
    public String? Description { get; set; }
    public double Price { get; set; }
    public String? Image { get; set; }
    public Boolean Vegetarian { get; set; } = false;
    public double? CalculatedRating { get; set; }
    public List<Rating> RawRating { get; set; } = new List<Rating>();
    public DishCategory Category { get; set; }
    public List<Basket> Basket { get; set; } = new List<Basket>();
    public List<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
}