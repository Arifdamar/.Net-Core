using Microsoft.EntityFrameworkCore;

namespace ORM_Entity_Framework_Core.Data.EfCore
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
    public class CustomNorthwindContext : NorthwindContext
    {
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public CustomNorthwindContext()
        {

        }
        public CustomNorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerOrder>(entity =>
                    {
                        entity.HasNoKey();

                        entity.Property(e => e.Name).HasColumnName("first_name");
                        entity.Property(e => e.CustomerId).HasColumnName("id");
                        entity.Property(e => e.Count).HasColumnName("count(*)");
                    });
        }
    }
}