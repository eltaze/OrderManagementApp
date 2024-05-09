﻿using DataBack.Model;
using System.ComponentModel.DataAnnotations;

namespace businessLogic.Model
{
    public class ProductsUI
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public List<OrderDetails> Details { get; set; } = new();
        
    }
}
