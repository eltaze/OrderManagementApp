using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic.Model
{
    public class OrderDetailsUI
    {
        public int Id { get; set; }
        [Required]
        public int  PridcutId { get; set; }
        [MaxLength(100)]
        public string Unit {  get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int OrderId { get; set; }
       


    }
}
