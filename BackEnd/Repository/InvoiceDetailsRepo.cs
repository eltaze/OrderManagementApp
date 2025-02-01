namespace BackEnd.Repository;

public class InvoiceDetailsRepo : RepositoryG<InvoicDetails>
{

    private readonly InvoiceContext context;
    private DbSet<InvoicDetails> dbSet;
    public InvoiceDetailsRepo(InvoiceContext context) : base(context)
    {
        this.context = context;
        dbSet = context.Set<InvoicDetails>();
    }
    public List<InvoicDetails> GetByOrderId(int id)
    {
        var result = dbSet.Where(x => x.OrderId.Equals(id));
        return result.ToList();
    }
    public List<InvoicDetails> GetByProdcutId(int id)
    {
        var result = dbSet.Where(x => x.PridcutId.Equals(id));
        return result.ToList();
    }
}

