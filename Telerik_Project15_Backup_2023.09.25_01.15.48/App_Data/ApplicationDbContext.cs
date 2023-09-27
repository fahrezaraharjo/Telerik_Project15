using System.Data.Entity;

namespace Telerik_Project15.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=ApplicationDbContext")
        {
            // Constructor logic if needed
        }

        public ApplicationDbContext(string ApplicationDbContext) : base(ApplicationDbContext)
        {
        }

        // DbSet properties for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<DestinationViewModel> DestinationViewModel { get; set; }
       
    }
}