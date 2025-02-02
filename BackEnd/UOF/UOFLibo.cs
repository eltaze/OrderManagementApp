
namespace BackEnd.UOF;

public class UOFLibo : IUOF, IDisposable
{
    private readonly InvoiceContext _context;
    public ProductRepo product { get; private set; }
    public InvoiceRepo Invoice { get; private set; }
    public InvoiceDetailsRepo InvoiceDetails { get; private set; }

    public UserRepo User { get; private set; }

    public UOFLibo(InvoiceContext context)
    {
        _context = context;
        product = new ProductRepo(context);
        Invoice = new InvoiceRepo(context);
        InvoiceDetails = new InvoiceDetailsRepo(context);
        User = new UserRepo(context);
    }

    public async Task ComplateTask()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Handle exception (e.g., log the error, rethrow, etc.)
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;  // Optionally rethrow the exception after handling it
        }
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }


}
