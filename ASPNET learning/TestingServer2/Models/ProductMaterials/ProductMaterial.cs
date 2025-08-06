namespace TestingServer2.Models
{
    public class ProductMaterial
    {
        public Guid MaterialId { get; set; }
        public float Quantity { get; set; } // The number of rivets, or square feet of leather
        public string Description { get; set; } // E.g., "Main body leather", "Closure hardware"
    }
}
