using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EShopDbContext _dbContext;
        public AccountRepository(EShopDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task AddNewUserRefreshToken(RefreshToken refreshToken)
        {
            await _dbContext.RefreshTokens.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RefreshToken>> GetUserRefreshTokens(Guid userId)
        {
            var tokens = await _dbContext.RefreshTokens.Where(x => x.UserId == userId).ToListAsync();
            return tokens;
        }
    }
}
