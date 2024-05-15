
namespace BackEnd.Repository;

public class OrderRepo : RepositoryG<Order>
{
   
         private readonly OrderContext context;
    private DbSet<Order> dbSet;
    public OrderRepo(OrderContext context) : base(context)
    {
        this.context = context;
        dbSet = context.Set<Order>();
    }
    public List<Order> GetByCustomerName(string id)
    {
        var result = dbSet.Where(x => x.CustomerName.Equals(id));
        return result.ToList();
    }
    public List<Order> GetByDates(DateTime StartDate , DateTime EndDate)
    {
        var result = dbSet.Where(x => x.orderDate.Date >=StartDate && x.orderDate <= EndDate);
                    
        return result.ToList();
    }
}

