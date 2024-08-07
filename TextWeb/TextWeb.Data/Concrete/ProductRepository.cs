﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextWeb.Data.Abstract;
using TextWeb.Entity;

namespace TextWeb.Data.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TextWebDbContext _dbContext) : base(_dbContext) { }
        private TextWebDbContext context
        {
            get { return _dbContext as TextWebDbContext; }
        }

        public async Task<List<Product>> ProductsByCategory(int categoryId)
        {
            var response = await context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return response;
        }
    }
}
