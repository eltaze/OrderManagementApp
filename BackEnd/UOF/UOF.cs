using BackEnd.Repository;
using DataBack.Data;



namespace BackEnd.UOF
{
    public class UOF : IUOF,IDisposable
    {
        private readonly OrderContext _context;

        
        public ProductRepo product { get; private set; } 
        public OrderRepo Order { get; private set; }
        public OrderDetailsRepo OrderDetails { get;private set; }

       
        public UOF(OrderContext context)
        {
            _context = context;
            product = new ProductRepo(context);
            Order =new OrderRepo(context);
            OrderDetails =new OrderDetailsRepo(context);
        }

        public async Task ComplateTask()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();   
        }

        
    }
}
