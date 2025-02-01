
namespace GrpcBackEnd.Services
{
    public class OrderDetailsGRPC : OrderDetailsServices.OrderDetailsServicesBase
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
            var result = await detailsBL.Add(order);
            return new IsordDet { IsDone = result };
        }
        public override async Task<IsordDet> Delete(GetId request, ServerCallContext context)
        {
            var result = await detailsBL.Delete(request.Id);
            return new IsordDet { IsDone = result };
        }
        public override async Task<OrderDetails> GetByOrderId(GetId request, ServerCallContext context)
        {
            OrderDetails orders = new OrderDetails();
            var result = detailsBL.GetByOrderId(request.Id);
            foreach (var item in result)
            {
                OrderDetail order = new OrderDetail
                {
                    Id = item.OrderId,
                    OrderId = item.OrderId,
                    Price = item.Price,
                    PridcutId = item.PridcutId,
                    Unit = item.Unit
                };
                orders.OrderDetails_.Add(order);

            }
            return orders;
        }
        public override async Task<OrderDetails> GetByProductId(GetId request, ServerCallContext context)
        {
            OrderDetails orders = new OrderDetails();
            var result = detailsBL.GetByProdcutId(request.Id);
            foreach (var item in result)
            {
                OrderDetail order = new OrderDetail
                {
                    Id = item.OrderId,
                    OrderId = item.OrderId,
                    Price = item.Price,
                    PridcutId = item.PridcutId,
                    Unit = item.Unit
                };
                orders.OrderDetails_.Add(order);

            }
            return orders;
        }
        public override async Task<IsordDet> Update(OrderDetail request, ServerCallContext context)
        {
            OrderDetailsUI order = new OrderDetailsUI
            {
                Id = request.OrderId,
                OrderId = request.OrderId,
                Price = request.Price,
                PridcutId = request.PridcutId,
                Unit = request.Unit
            };
            var result = await detailsBL.Update(order);
            return new IsordDet { IsDone = result };
        }
    }
}
