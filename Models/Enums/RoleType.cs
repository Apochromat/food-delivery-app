using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace food_delivery_app.Models.Enums {
    public enum RoleType {
        [Display(Name = ApplicationRoleNames.Administrator)]
        Administrator,
        [Display(Name = ApplicationRoleNames.User)]
        User
    }

    public class ApplicationRoleNames {
        public const string Administrator = "Администратор";
        public const string User = "Пользователь";
    }
}
