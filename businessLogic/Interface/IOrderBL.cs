namespace businessLogic.Interface
{
    public interface IOrderBL
    {
        Task<bool> Add(OrderUI entity);
        Task<List<OrderUI>> All();
        Task<bool> Delete(int id);
        List<OrderUI> GetByCustomerName(string CustomerName);
        Task<OrderUI> GetById(int id);
        List<OrderUI> orderdate(DateTime StartDate, DateTime EndDate);
        Task<bool> Update(OrderUI entity);
    }
}