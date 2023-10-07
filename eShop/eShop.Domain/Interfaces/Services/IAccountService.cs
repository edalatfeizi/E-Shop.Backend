
namespace eShop.Domain.Interfaces.Services;

public interface IAccountService
{
    public Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId);
    public Task AddUserRefreshTokenAsync(Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate);
    public Task UpdateUserRefreshTokenAsync(Guid id, Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate);

}
