using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextWeb.Data.Abstract;

namespace TextWeb.Data.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
             _dbContext.Add(entity);
            try
            {
                var result = await  _dbContext.SaveChangesAsync();
                return result > 0 ? entity : null;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? entity : null;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _dbContext.Set<TEntity>().ToListAsync();

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<ICollection<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? entity : null;
        }
    }
}
