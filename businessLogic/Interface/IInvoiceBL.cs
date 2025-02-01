namespace businessLogic.Interface
{
    public interface IInvoiceBL
    {
        Task<bool> Add(InvoiceUI entity);
        Task<List<InvoiceUI>> All();
        Task<bool> Delete(int id);
        List<InvoiceUI> GetByCustomerName(string CustomerName);
        Task<InvoiceUI> GetById(int id);
        List<InvoiceUI> orderdate(DateTime StartDate, DateTime EndDate);
        Task<bool> Update(InvoiceUI entity);
    }
}