

namespace businessLogic.Model;

public class InvoiceDetailsUI
{
    public int Id { get; set; }
    [Required]
    public int PridcutId { get; set; }
    [MaxLength(100)]
    public string Unit { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int OrderId { get; set; }



}
