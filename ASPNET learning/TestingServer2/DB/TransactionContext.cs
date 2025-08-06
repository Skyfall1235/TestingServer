using Microsoft.EntityFrameworkCore;
using TestingServer2.Models.Users;

namespace TestingServer2.DB
{
    public class TransactionContext : DbContext
    {
        // Your main entities
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // The related entities that need their own tables
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }
        public TransactionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShippingCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Tax)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderLineItem>()
                .Property(o => o.PriceAtPurchase)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderLineItem>()
                .Property(o => o.Total)
                .HasPrecision(18, 2);

            // Configure the relationship between Order and Customer
            // An Order has one Customer, and a Customer has many Orders.
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Important: Prevents deleting a customer with orders

            // Configure the relationships from Order to CustomerAddress
            // This is the source of the "multiple cascade paths" error.
            // We tell EF Core that a ShippingAddress has many Orders, but do not delete them.
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // We do the same for BillingAddress.
            modelBuilder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship from Order to OrderLineItem
            // An Order has many LineItems. When an Order is deleted,
            // we want all its line items to be deleted too.
            modelBuilder.Entity<OrderLineItem>()
                .HasOne<Order>()
                .WithMany(o => o.LineItems)
                .HasForeignKey("OrderId") // EF Core automatically creates this FK
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship from Customer to CustomerAddress
            // A Customer has one Address, and an Address can belong to many Customers.
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // This is important: call the base method after your custom code
            base.OnModelCreating(modelBuilder);
        }
    }
}
