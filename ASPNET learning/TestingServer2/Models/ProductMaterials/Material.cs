namespace TestingServer2.Models
{
    public abstract class Material
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float PricePerUnit { get; set; }
        public string UnitOfMeasure { get; set; } // e.g., "per meter", "per square foot"
    }
}
