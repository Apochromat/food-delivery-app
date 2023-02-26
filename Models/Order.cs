using System.ComponentModel.DataAnnotations;
using food_delivery_app.Models.Enums;

namespace food_delivery_app.Models;

public class Order {
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DeliveryTime { get; set; }
    public DateTime OrderTime { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; } = OrderStatus.InProcess;
    public double Price { get; set; }
    public String Address { get; set; }
    public ICollection<OrderDish> OrderDishes { get; set; }
}