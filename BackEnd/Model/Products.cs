

namespace DataBack.Model;

public class Products
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(250)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public List<OrderDetails> Details { get; set; } = new();
    
}
