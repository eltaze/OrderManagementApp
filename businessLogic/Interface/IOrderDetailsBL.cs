namespace businessLogic.Interface
{
    public interface IOrderDetailsBL
    {
        Task<bool> Add(OrderDetailsUI entity);
        Task<List<OrderDetailsUI>> All();
        Task<bool> Delete(object id);
        Task<OrderDetailsUI> GetById(int id);
        List<OrderDetailsUI> GetByOrderId(int id);
        List<OrderDetailsUI> GetByProdcutId(int id);      
        Task<bool> Update(OrderDetailsUI entity);
    }
}