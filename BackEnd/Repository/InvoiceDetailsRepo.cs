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
    var result = dbSet.Where(x => x.invoices.Id.Equals(id));
    return result.ToList();
  }
  public List<InvoicDetails> GetByProdcutId(int id)
  {
    var result = dbSet.Where(x => x.Products.Id.Equals(id));
    return result.ToList();
  }
  public List<InvoicDetails> GetPage(int pageNumber, int invoiceid, int pageSize = 10)
  {
    // var dbSet = _context.Set<InvoicDetails>();


    List<InvoicDetails> result = dbSet.Where(x => x.invoiceId == invoiceid)
        .OrderBy(x => x.Id)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return result;
  }

}

