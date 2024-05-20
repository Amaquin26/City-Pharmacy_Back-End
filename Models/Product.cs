using CityPharmacyAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CityPharmacyAPI.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string DirectionsForUse { get; set; }

        public string WarningsPrecautions { get; set; }

        public string PackagingSize { get; set; }    
        public decimal Price { get; set; }

        public string StorageConditions { get; set; }

        public string StorageLocation { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }
        public ItemStatus ItemStatus { get; set; } = ItemStatus.Active;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
