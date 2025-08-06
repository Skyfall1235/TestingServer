using System.Drawing;

namespace TestingServer2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public List<ProductMaterial> Recipe { get; set; }
    }

    public enum ColorType
    {
        Natural,
        GreenDyed,
        TanDyed,
        BlackDyed,
        Other
    }
    public enum MetalType
    {
        Steel,
        Nickel,
        Aluminum,
        Brass,
        Copper,
        Other
    }
    public enum HardwareType
    {
        ButtonFastener,
        CopperRivet,
        DoubleCapRivet,
        DRing,
        ORing,
        BoxRing,
        MagentClip,
        Clasp,
        Other
    }
    public enum TanningType
    {
        VegetableTanned,
        ChromeTanned,
        Other,
    }
}
