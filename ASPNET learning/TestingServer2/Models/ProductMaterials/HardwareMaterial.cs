namespace TestingServer2.Models
{
    public class  HardwareMaterial : Material
    {
        public MetalType Metal { get; set; }
        public HardwareType Type { get; set; }
        public float SizeInMm { get; set; }
        
    }
}
