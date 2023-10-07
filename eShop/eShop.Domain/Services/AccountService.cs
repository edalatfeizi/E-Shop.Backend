using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        public AccountService(IAccountRepository accountRepo)
        {

            _accountRepo = accountRepo;

        }

        public async Task AddUserRefreshToken(RefreshToken refreshToken)
        {
            await _accountRepo.AddNewUserRefreshToken(refreshToken);
        }

        public async Task<List<RefreshToken>> GetUserRefreshTokens(Guid userId)
        {
            var tokens = await _accountRepo.GetUserRefreshTokens(userId);

            return tokens;
        }
    }
}
