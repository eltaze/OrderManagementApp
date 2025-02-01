
namespace DataBack.Model;

public class InvoicDetails
{
    public int Id { get; set; }
    [Required]
    public Products Products { get; set; }
    [MaxLength(100)]
    public string Unit { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public Invoices invoices { get; set; }

    public int invoiceId { get; set; }
    public int ProductId { get; set; }



}
