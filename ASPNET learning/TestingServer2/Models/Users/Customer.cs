using System.ComponentModel.DataAnnotations;

namespace TestingServer2.Models.Users
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(100)]
        public string? CustomerName { get; set; }

        [Required]
        [Phone] // This is a built-in validation for phone numbers
        [MaxLength(35)]
        public string? PhoneNumber { get; set; }

        public CustomerAddress? Address { get; set; }

        public required ICollection<Order> Orders { get; set; }
    }
}
