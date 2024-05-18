
namespace businessLogic.Model;

public class ProductsUI
{
    public int Id { get; set; }
   
    public string Name { get; set; }
   
    public string Description { get; set; }
    
    public double Price { get; set; }
    public List<OrderDetails> Details { get; set; } = new();
    
}
