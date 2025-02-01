
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
    public double Price { get; set; }
    public List<InvoicDetails> Details { get; set; } = new();

}
