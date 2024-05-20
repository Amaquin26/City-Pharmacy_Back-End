using CityPharmacyAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace CityPharmacyAPI.Models
{
    public class Medicine
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public string GenericName { get; set; }

        public string Manufacturer { get; set; }

        public string NationalDrugCode { get; set; }
        
        public string Description { get; set; }

        public string Strength { get; set; }

        public string DosageForm { get; set; }

        public string PackagingSize { get; set; }

        public string PackagingType { get; set; }

        public string TherapeuticIndications { get; set; }

        public string IntendedUse { get; set; }

        public decimal Price { get; set; }

        public string StorageConditions { get; set; }

        public string StorageLocation { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }
        public ItemStatus ItemStatus { get; set; } = ItemStatus.Active;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
