using Microsoft.AspNetCore.Identity;

namespace CityPharmacyAPI.Models
{
    public class AppRole : IdentityRole
    {
        public const string Admin = "Admin";
        public const string Staff = "Staff";
    }
}
