

using System.Security.Cryptography.X509Certificates;

namespace BackEnd.Repository;

public class OrderDetailsRepo : RepositoryG<OrderDetails>
{
   
    private readonly OrderContext context;
    private DbSet<OrderDetails> dbSet;
    public OrderDetailsRepo(OrderContext context) : base(context)
    {
        this.context = context;
        dbSet = context.Set<OrderDetails>();
    }
    public List<OrderDetails> GetByOrderId(int id)
    {
        var result = dbSet.Where(x => x.OrderId.Equals(id));
        return result.ToList();
    }
    public List<OrderDetails> GetByProdcutId(int id)
    {
        var result = dbSet.Where(x => x.PridcutId.Equals(id));
        return result.ToList();
    }
}

