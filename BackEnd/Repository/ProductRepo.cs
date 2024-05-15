
namespace BackEnd.Repository;

public class ProductRepo : RepositoryG<Products>
{
    private readonly OrderContext context;
    DbSet<Products> dbSet;
    public ProductRepo(OrderContext context) : base(context)
    {
        this.context = context;
        dbSet = context.Set<Products>();
    }
    public   List<Products> getByName(string id)
    {
        var result =  dbSet.Where(x=> x.Name.Equals(id));
        return result.ToList();
    }
}
