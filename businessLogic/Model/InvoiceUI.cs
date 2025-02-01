

namespace businessLogic.Model;

public class InvoiceUI
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public DateTime orderDate { get; set; }
    public DateTime DueDate { get; set; }
    public List<InvoiceDetailsUI> Details { get; set; } = new List<InvoiceDetailsUI>();

}
