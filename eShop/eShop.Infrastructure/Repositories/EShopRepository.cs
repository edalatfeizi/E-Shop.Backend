using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class EShopRepository<T> : RepositoryBase<T> where T : class
    {
        private readonly EShopDbContext _context;
        public EShopRepository(EShopDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
