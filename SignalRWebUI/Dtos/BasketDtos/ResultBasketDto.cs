﻿using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public ResultProductDto Product { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}
