using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TextWeb.Data.Abstract
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression);
    }
}
