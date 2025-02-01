
namespace BackEnd.Repository;

public class InvoiceRepo : RepositoryG<Invoices>
{

    private readonly InvoiceContext context;
    private DbSet<Invoices> dbSet;
    public InvoiceRepo(InvoiceContext context) : base(context)
    {
        this.context = context;
        dbSet = context.Set<Invoices>();
    }
    public List<Invoices> GetByCustomerName(string id)
    {
        var result = dbSet.Where(x => x.CustomerName.Equals(id));
        return result.ToList();
    }
    public List<Invoices> GetByDates(DateTime StartDate, DateTime EndDate)
    {
        var result = dbSet.Where(x => x.orderDate.Date >= StartDate && x.orderDate <= EndDate);

        return result.ToList();
    }
}

