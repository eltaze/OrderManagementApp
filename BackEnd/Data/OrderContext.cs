
namespace DataBack.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> orderDetails { get; set; }
    public DbSet<Products> products { get; set; }
}
