using businessLogic.Interface;
using businessLogic.Model;
using Eltaze.Protos;
using Grpc.Core;

namespace GrpcBackEnd.Services
{
    public class OrderDetailsGRPC :OrderDetailsServices.OrderDetailsServicesBase
    {
        private readonly IOrderDetailsBL detailsBL;

        public OrderDetailsGRPC(IOrderDetailsBL detailsBL)
        {
            this.detailsBL = detailsBL;
        }
        public override async Task<IsordDet> Create(OrderDetail request, ServerCallContext context)
        {
            OrderDetailsUI order = new OrderDetailsUI
            {
                Id = request.OrderId,
                OrderId = request.OrderId,
                Price = request.Price,
                PridcutId = request.PridcutId,
                Unit = request.Unit
            };
            var result =await detailsBL.Add(order);
            return new IsordDet { IsDone = result };
        }
        public override Task<IsordDet> Delete(Id request, ServerCallContext context)
        {
            return base.Delete(request, context);
        }
        public override Task<OrderDetails> GetByOrderId(Id request, ServerCallContext context)
        {
            return base.GetByOrderId(request, context);
        }
        public override Task<OrderDetails> GetByProductId(Id request, ServerCallContext context)
        {
            return base.GetByProductId(request, context);
        }
        public override Task<IsordDet> Update(OrderDetail request, ServerCallContext context)
        {
            return base.Update(request, context);
        }
    }
}
