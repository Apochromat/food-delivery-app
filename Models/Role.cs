using food_delivery_app.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace food_delivery_app.Models {
    public class Role : IdentityRole<Guid> {
        public RoleType Type { get; set; }
        public ICollection<UserRole> Users { get; set; }
    }

}
