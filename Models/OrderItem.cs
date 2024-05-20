namespace CityPharmacyAPI.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
