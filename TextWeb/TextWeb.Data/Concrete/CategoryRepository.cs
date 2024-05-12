using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextWeb.Data.Abstract;
using TextWeb.Entity;

namespace TextWeb.Data.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TextWebDbContext _dbContext) : base(_dbContext){ }
        private TextWebDbContext context
        {
            get { return _dbContext as TextWebDbContext; }
        }

        public async Task<List<Category>> GetAllCategoryWithProductsAsync()
        {
            var categoryList = await context.Categories.Where(c => c.IsActive)
                .Include(c => c.Products)
                .ToListAsync();
            return categoryList;
        }
    }
}
