using AutoMapper;
using BackEnd.Repository;
using BackEnd.UOF;
using businessLogic.Model;
using DataBack.Model;
using Microsoft.Extensions.Logging;

namespace businessLogic.BL
{
    public class OrderDetailsBL(IMapper mapper ,IUOF uOF )
    {
        
        
        private readonly IMapper mapper = mapper;
        private readonly IUOF uOF = uOF;

        public async Task<List<OrderDetailsUI>> All()
        {
            var result =  await uOF.OrderDetails.All();
            if (result == null) { return null; }
            return mapper.Map<List<OrderDetailsUI>>(result);
        }
        public async  Task<OrderDetailsUI> GetById(int id)
        {
            var result = await uOF.OrderDetails.GetById(id);
            if (result == null) { return null; }
            return mapper.Map<OrderDetailsUI>(result);
        }
        public async Task<List<OrderDetailsUI>> GetPyProduct(int id)
        {
            var result = await uOF.OrderDetails.GetByT(id, "PridcutId");
            if (result == null) { return null; }
            return mapper.Map<List<OrderDetailsUI>>(result);
        }
        public async Task<List<OrderDetailsUI>> GetByOrder(int id)
        {
            var result = await uOF.OrderDetails.GetByT(id, "OrderId");
            if (result == null) { return null; }
            return mapper.Map<List<OrderDetailsUI>>(result);
        }
        public async Task<bool> Add(OrderDetailsUI entity)
        {
            var details=mapper.Map<OrderDetails>(entity);

            var result = await uOF.OrderDetails.Add(details);
            await uOF.ComplateTask();
            return result;
        }
        public async Task<bool> Delete(object id)
        {
            var result = await uOF.OrderDetails.Delete(id);
            await uOF.ComplateTask();
            return result;
        }
        public async Task<bool> Update(OrderDetailsUI entity)
        {
            var details = mapper.Map<OrderDetails>(entity);
            var result = await uOF.OrderDetails.Update(details);
            await uOF.ComplateTask();
            return result;
        }
    }
}
