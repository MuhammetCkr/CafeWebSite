﻿using TextWeb.Entity;

namespace TextWeb.Model
{
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

    }
}
