
namespace BackEnd.UOF;

public interface IUOF
{
    public ProductRepo product { get; }
    public InvoiceRepo Invoice { get; }
    public InvoiceDetailsRepo InvoiceDetails { get; }
    public UserRepo User { get; }
    Task ComplateTask();
    void Dispose();

}
