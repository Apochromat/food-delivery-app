namespace food_delivery_app.Models {
    public class Rating {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Dish Dish { get; set; }
        public int RatingValue { get; set; }
    }
}
