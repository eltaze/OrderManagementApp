using BackEnd.Model;
using DataBack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repository
{
    public class ProductRepo : RepositoryG<Products>
    {
        public ProductRepo(OrderContext context) : base(context)
        {
        }
    }
}
