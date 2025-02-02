
using BackEnd.Model;
using DataBack.Model;

namespace DataBack.Data;

public class InvoiceContext : DbContext, IDisposable
{
  public InvoiceContext(DbContextOptions options) : base(options) { }
  public DbSet<Invoices> Invoices { get; set; }
  public DbSet<InvoicDetails> InvoicDetails { get; set; }
  public DbSet<Products> products { get; set; }
  public DbSet<Users> users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Invoices>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();
    modelBuilder.Entity<InvoicDetails>()
        .Property(d => d.Id)
        .ValueGeneratedOnAdd();
    modelBuilder.Entity<Products>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();
    modelBuilder.Entity<Users>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();
    modelBuilder.Entity<InvoicDetails>()
        .HasOne(d => d.invoices)
        .WithMany(i => i.Details)
        .HasForeignKey(d => d.invoiceId);
    modelBuilder.Entity<InvoicDetails>()
        .HasOne(d => d.Products)
        .WithMany(i => i.Details)
        .HasForeignKey(d => d.ProductId);
  }

  public void Dispose()
  {
    // Dispose logic here
    base.Dispose();
  }
}
