
namespace BackEnd.UOF;

public interface IUOF
{
    public ProductRepo product { get; }
    public OrderRepo Order { get;  }
    public OrderDetailsRepo OrderDetails { get;}
    Task ComplateTask();
    void Dispose();
  
}
