
using eShop.Domain.Entities;

namespace eShop.Domain.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<RefreshToken> AddUserRefreshTokenAsync(Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate);
    Task<bool?> UpdateUserRefreshTokenAsync(Guid id, Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate);
    Task<List<RefreshToken>> GeUserRefreshTokensAsync(Guid userId);
}
