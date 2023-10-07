using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<List<RefreshToken>> GetUserRefreshTokens(Guid userId);
        public Task AddUserRefreshToken(RefreshToken refreshToken);

    }
}
