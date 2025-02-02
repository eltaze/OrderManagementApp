using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Data
{
  public class InMemoryDatabaseService : IDisposable
  {
    private readonly DbContextOptions<InvoiceContext> _options;

    public InMemoryDatabaseService()
    {
      // Configure the DbContextOptions for the in-memory database
      _options = new DbContextOptionsBuilder<InvoiceContext>()
          .UseInMemoryDatabase("InvoiceDB") // Database name for in-memory store
          .Options;
    }

    // Method to create a new DbContext instance
    public InvoiceContext CreateContext()
    {
      return new InvoiceContext(_options);
    }

    public void Dispose()
    {
      // Clean up resources if needed
    }
  }
}
