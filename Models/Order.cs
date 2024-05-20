using CityPharmacyAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CityPharmacyAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
        public int AppUserId { get; set; }
        public AppUser User { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
