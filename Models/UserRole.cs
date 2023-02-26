using Microsoft.AspNetCore.Identity;

namespace food_delivery_app.Models {
    public class UserRole : IdentityUserRole<Guid> {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

    }
}
