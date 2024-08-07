﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextWeb.Entity;

namespace TextWeb.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> ProductsByCategory(int categoryId);
    }
}
