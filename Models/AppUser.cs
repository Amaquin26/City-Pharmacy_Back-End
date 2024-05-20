using CityPharmacyAPI.Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace CityPharmacyAPI.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Today;
        public string? GoogleSecretKey { get; set; }
        public string? ProfileImagePath { get; set; }
        public IdentityStatus Status { get; set; } = IdentityStatus.Inactive;
    }
}
