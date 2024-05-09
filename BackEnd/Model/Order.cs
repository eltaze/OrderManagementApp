using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBack.Model
{
    public class Order
    {
       public int Id { get; set; }
       public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress {  get; set; }
        public DateTime orderDate { get; set; }
        public DateTime DueDate { get; set; }
        public List<OrderDetails> Details { get; set; }=new List<OrderDetails>();

    }
}
