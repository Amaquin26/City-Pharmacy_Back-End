using System.ComponentModel.DataAnnotations;

namespace CityPharmacyAPI.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? ProductId { get; set; }
        public int? MedicineId { get; set; }

        public int BeginningInventory { get; set; }

        public int? EndingInventory { get; set; }
        public Product? Product { get; set; }   
        public Medicine? Medicine { get; set; } 
    }
}
