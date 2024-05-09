using AutoMapper;
using BackEnd.Repository;
using BackEnd.UOF;
using businessLogic.Model;
using DataBack.Model;
using Microsoft.Extensions.Logging;


namespace businessLogic.BL
{
    public class OrderBL(IMapper mapper,IUOF uOF)
    {
        
        private readonly IUOF uOF = uOF;
  
        private readonly IMapper mapper;
        public async Task<List<OrderUI>> All()
        {
            var result = await uOF.Order.All();
            if(result == null) { return null; }
            return mapper.Map<List<OrderUI>>( result.ToList());
        }
        public async Task<OrderUI> GetById(int id)
        {
            var result = await uOF.Order.GetById(id);
            if (result == null) { return null; }
            return mapper.Map<OrderUI>( result);
        }
        public async Task<List<OrderUI>> GetByCustomerName(string CustomerName)
        {
            var result = await uOF.Order.GetByT(CustomerName, "CustomerName");
            if (result == null) { return null; }
            return mapper.Map<List<OrderUI>>(result.ToList());
        }
        public async Task<List<OrderUI>> GetByCustomerEmail(string Email)
        {
            var result = await uOF.Order.GetByT(Email, "CustomerEmail");
            if (result == null) { return null; }
            return mapper.Map<List<OrderUI>>(result.ToList());
        }
       public async Task<bool> Add(OrderUI entity)
        {
            var ord = mapper.Map<Order>(entity);
            var result = await uOF.Order.Add(ord);
            await uOF.ComplateTask();
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            var result = await uOF.Order.Delete(id);
            await uOF.ComplateTask();
            return result;
        }

        public async Task<bool> Update(OrderUI entity)
        {
            var ord = mapper.Map<Order>(entity);
            var result = await uOF.Order.Update(ord);
            await uOF.ComplateTask();
            return result;
        }
    }
}
