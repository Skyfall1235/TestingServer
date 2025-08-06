using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace TestingServer2.Models
{
    public class  LeatherMaterial : Material
    {
        public TanningType Tanning { get; set; }
        public float ThicknessInMm { get; set; }
        public ColorType Color { get; set; }
        public string CustomColorHex { get; set; } // Optional, for custom colors
    }
}
