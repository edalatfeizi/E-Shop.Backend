
namespace eShop.Domain.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepo;
    public AccountService(IAccountRepository accountRepo)
    {

        _accountRepo = accountRepo;

    }

    public async Task AddUserRefreshTokenAsync(Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate)
    {
        var refreshToken = new RefreshToken()
        {
            UserId = userId,
            Token = token,
            JwtId = jwtId,
            IsUsed = isUsed,
            IsRevoked = isRevoked,
            AddedDate = addedDate,
            ExpiryDate = expiryDate
        };
        await _accountRepo.AddNewUserRefreshTokenAsync(refreshToken);
    }

    public async Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId)
    {
        var tokens = await _accountRepo.GetUserRefreshTokensAsync(userId);

        return tokens;
    }

    public async Task UpdateUserRefreshTokenAsync(Guid id, Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate)
    {
        var refreshToken = new RefreshToken()
        {
            Id = id,
            UserId = userId,
            Token = token,
            JwtId = jwtId,
            IsUsed = isUsed,
            IsRevoked = isRevoked,
            AddedDate = addedDate,
            ExpiryDate = expiryDate
        };
        await _accountRepo.UpdateUserRefreshTokenAsync(refreshToken);
    }
}
