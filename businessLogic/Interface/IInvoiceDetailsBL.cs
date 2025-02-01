namespace businessLogic.Interface
{
    public interface IInvoiceDetailsBL
    {
        Task<bool> Add(InvoiceDetailsUI entity);
        Task<List<InvoiceDetailsUI>> All();
        Task<bool> Delete(object id);
        Task<InvoiceDetailsUI> GetById(int id);
        List<InvoiceDetailsUI> GetByOrderId(int id);
        List<InvoiceDetailsUI> GetByProdcutId(int id);
        Task<bool> Update(InvoiceDetailsUI entity);
    }
}