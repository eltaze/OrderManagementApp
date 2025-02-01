using businessLogic.Model;

namespace GrpcBL.Interfaces
{
    public interface IOrderServ
    {
        Task<bool> Create(OrderUI order);
        Task<bool> delete(int id);
        Task<List<OrderUI>> GetbyCustomerName(string name);
        Task<List<OrderUI>> GetByOrderDate(DateTime SDates, DateTime Edates);
        Task<OrderUI> GetByOrderId(int id);
        Task<List<OrderUI>> GetOrders();
        Task<bool> Update(OrderUI order);
    }
}