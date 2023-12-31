﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.DTO
{
    public class OrderLineDto : Dto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateOrderLineDto : Dto
    {
        public int BavSizeId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceForOne { get; set; }
    }

}
