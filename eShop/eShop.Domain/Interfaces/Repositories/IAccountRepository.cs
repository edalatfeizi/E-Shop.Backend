using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        public Task<List<RefreshToken>> GetUserRefreshTokens(Guid userId);
        public Task AddNewUserRefreshToken(RefreshToken refreshToken);
    }
}
