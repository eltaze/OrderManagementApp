using BackEnd.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.UOF
{
    public interface IUOF
    {
        public ProductRepo product { get; }
        public OrderRepo Order { get;  }
        public OrderDetailsRepo OrderDetails { get;}
        Task ComplateTask();
        void Dispose();
      
    }
}
