using businessLogic.BL;
using businessLogic.Model;
using Eltaze.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcBL.Interfaces;

namespace GrpcBL.BL
{
    public class OrderServ : IOrderServ
    {
        private readonly OrdersServices.OrdersServicesClient client;

        public OrderServ(OrdersServices.OrdersServicesClient client)
        {
            this.client = client;
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //  ,new GrpcChannelOptions { HttpHandler = handler });
            client = new OrdersServices.OrdersServicesClient(channel);
        }
        public async Task<List<OrderUI>> GetOrders()
        {
            var result = new List<OrderUI>();
            var req = await client.GettAllAsync(new Emty());
            foreach (OrderModel item in req.OrderModel)
            {
                OrderUI uI = new OrderUI
                {
                    CustomerAddress = item.CustomerAddress,
                    CustomerEmail = item.CustomerEmail,
                    CustomerName = item.CustomerName,
                    DueDate = item.DueDate.ToDateTime(),
                    Id = item.Id,
                    orderDate = item.OrderDate.ToDateTime()
                };
                result.Add(uI);
            }
            return result;
        }
        public async Task<List<OrderUI>> GetbyCustomerName(string name)
        {
            var result = new List<OrderUI>();
            GetByCustomer get = new GetByCustomer { Name = name };
            var req = await client.GetByCustomerNameAsync(get);
            foreach (OrderModel item in req.OrderModel)
            {
                OrderUI uI = new OrderUI
                {
                    CustomerAddress = item.CustomerAddress,
                    CustomerEmail = item.CustomerEmail,
                    CustomerName = item.CustomerName,
                    DueDate = item.DueDate.ToDateTime(),
                    Id = item.Id,
                    orderDate = item.OrderDate.ToDateTime()
                };
                result.Add(uI);
            }
            return result;
        }
        public async Task<List<OrderUI>> GetByOrderDate(DateTime SDates, DateTime Edates)
        {
            var result = new List<OrderUI>();
            var Sdate = SDates.ToTimestamp();
            var Edate = Edates.ToTimestamp();
            GetByDate get = new GetByDate { StartDate = Sdate, EndDate = Edate };
            var req = await client.GetByOrderDateAsync(get);
            foreach (OrderModel item in req.OrderModel)
            {
                OrderUI uI = new OrderUI
                {
                    CustomerAddress = item.CustomerAddress,
                    CustomerEmail = item.CustomerEmail,
                    CustomerName = item.CustomerName,
                    DueDate = item.DueDate.ToDateTime(),
                    Id = item.Id,
                    orderDate = item.OrderDate.ToDateTime()
                };
                result.Add(uI);
            }
            return result;
        }
        public async Task<OrderUI> GetByOrderId(int id)
        {
            orderLookUp id1 = new orderLookUp { Id = id };
            var result = await client.GetByOrderIdAsync(id1);
            OrderUI uI = new OrderUI
            {
                CustomerAddress = result.CustomerAddress,
                CustomerEmail = result.CustomerEmail,
                CustomerName = result.CustomerName,
                DueDate = result.DueDate.ToDateTime(),
                orderDate = result.OrderDate.ToDateTime(),
                Id = result.Id
            };
            return uI;
        }
        public async Task<bool> Create(OrderUI order)
        {
            OrderModel model = new OrderModel
            {
                Id = order.Id,
                CustomerAddress = order.CustomerAddress,
                CustomerEmail = order.CustomerEmail,
                CustomerName = order.CustomerName,
                DueDate = order.DueDate.ToTimestamp(),
                OrderDate = order.orderDate.ToTimestamp()
            };
            var result = await client.CtreateAsync(model);
            return result.Rest;
        }
        public async Task<bool> Update(OrderUI order)
        {
            OrderModel model = new OrderModel
            {
                Id = order.Id,
                CustomerAddress = order.CustomerAddress,
                CustomerEmail = order.CustomerEmail,
                CustomerName = order.CustomerName,
                DueDate = order.DueDate.ToTimestamp(),
                OrderDate = order.orderDate.ToTimestamp()
            };
            var result = await client.UpdateAsync(model);
            return result.Rest;
        }
        public async Task<bool> delete(int id)
        {
            orderLookUp up = new orderLookUp { Id = id };
            var result = await client.DeleteAsync(up);
            return result.Rest;
        }
    }
}
