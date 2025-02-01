
using BackEnd.Model;

namespace DataBack.Data;

public class InvoiceContext : DbContext
{
    public InvoiceContext(DbContextOptions options) : base(options) { }
    public DbSet<Invoices> Orders { get; set; }
    public DbSet<InvoicDetails> orderDetails { get; set; }
    public DbSet<Products> products { get; set; }
    public DbSet<Users> users { get; set; }
}
