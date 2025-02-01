using businessLogic.Model;
using Eltaze.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcBL.BL
{
    public class OrderDetailServ
    {
        private readonly OrderDetailsServices.OrderDetailsServicesClient client;

        public OrderDetailServ(OrderDetailsServices.OrderDetailsServicesClient client)
        {
            this.client = client;
        }
        public async Task<bool>Create(OrderDetailsUI order)
        {
            OrderDetail ord = new OrderDetail
            {
                Id = order.Id,
                OrderId = order.OrderId,
                Price = order.Price,
                PridcutId = order.PridcutId,
                Unit = order.Unit
            };
            var result = await client.CreateAsync(ord);
            return result.IsDone;
        }
        public async Task<bool> Update(OrderDetailsUI order)
        {
            OrderDetail ord = new OrderDetail
            {
                Id = order.Id,
                OrderId = order.OrderId,
                Price = order.Price,
                PridcutId = order.PridcutId,
                Unit = order.Unit
            };
            var result = await client.UpdateAsync(ord);
            return result.IsDone;
        }
        //public async Task<bool> Delete (int id)
        //{
        //    GetId.IdFieldNumber = id;
        //}
    }
}
