
namespace eShop.Domain.Interfaces.Repositories;

public interface IAccountRepository
{
    public Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId);
    public Task AddNewUserRefreshTokenAsync(RefreshToken refreshToken);
    public Task UpdateUserRefreshTokenAsync(RefreshToken refreshToken);
}
