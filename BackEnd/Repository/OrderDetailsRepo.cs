using DataBack.Data;
using DataBack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repository
{
    public class OrderDetailsRepo : RepositoryG<OrderDetails>
    {
        public OrderDetailsRepo(OrderContext context) : base(context)
        {
        }
    }
}
