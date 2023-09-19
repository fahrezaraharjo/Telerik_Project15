using System.Collections.Generic;
using System.Data.Entity;
using System; // Import the System namespace
using Telerik_Project15.Models; // Import your project's namespace

namespace Telerik_Project15.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=koneksi")
        {
            // Constructor logic if needed
        }

        // DbSet properties for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}