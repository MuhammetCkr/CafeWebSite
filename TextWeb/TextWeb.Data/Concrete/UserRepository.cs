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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TextWebDbContext _dbContext) : base(_dbContext) { }
        private TextWebDbContext context
        {
            get { return context as TextWebDbContext; }
        }
    }
}
