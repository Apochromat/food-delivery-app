namespace food_delivery_app.Models {
    public class OrderDish {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Order Order { get; set; }
        public Dish Dish { get; set; } 
        public int Amount { get; set; }
    }
}
