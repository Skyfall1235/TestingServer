using System.Net;

namespace TestingServer2.Models.Users
{

    public enum OrderStatus
    {
        Pending,        // Order has been placed, but not yet started
        InProgress,     // Materials are being gathered and the item is being made
        ReadyForShipping, // Item is complete and waiting to be shipped
        Shipped,        // Order has been shipped to the customer
        Completed,      // Order has been delivered
        Cancelled,      // Order has been cancelled
        Refunded        // Order has been refunded
    }
    public class Order
    {
        public int Id { get; set; }
        // Link to the customer who placed the order
        public int CustomerId { get; set; }

        // Status and timestamps
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; } // The '?' makes it nullable, in case it hasn't shipped yet

        // Financial details
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        // Shipping and billing information
        public CustomerAddress? ShippingAddress { get; set; }
        public required CustomerAddress BillingAddress { get; set; }

        // A list of the items that were purchased in this order
        public required List<OrderLineItem> LineItems { get; set; }
    }

    public class OrderLineItem
    {
        // Link to the product that was ordered
        public int id { get; set; }
        // We use the Product's public ID for consistency
        public Guid ProductPublicId { get; set; }
    
        // The name of the product at the time of purchase
        public required string ProductName { get; set; }
    
        // The unit price at the time of purchase
        public decimal PriceAtPurchase { get; set; }
    
        // How many units were purchased
        public int Quantity { get; set; }
    
        // The total for this line item (PriceAtPurchase * Quantity)
        public decimal Total { get; set; }
    
        // Any customization notes for this specific item
        public string? CustomizationNotes { get; set; }
    }
}

