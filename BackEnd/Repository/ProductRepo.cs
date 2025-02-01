
namespace BackEnd.Repository;

public class ProductRepo : RepositoryG<Products>
{
    private readonly InvoiceContext context;
    DbSet<Products> dbSet;
    public ProductRepo(InvoiceContext context) : base(context)
    {
        this.context = context;
        dbSet = context.Set<Products>();
    }
    public List<Products> getByName(string id)
    {
        var result = dbSet.Where(x => x.Name.Equals(id));
        return result.ToList();
    }
}
