
using eShop.Domain.Entities;

namespace eShop.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly EShopDbContext _context;
    public AccountRepository(EShopDbContext context)
    {
        _context = context;
    }
    public async Task<RefreshToken> AddUserRefreshTokenAsync(Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate)
    {
        var refreshToken = new RefreshToken
        {
            UserId = userId,
            Token = token,
            JwtId = jwtId,
            IsUsed = isUsed,
            IsRevoked = isRevoked,
            AddedDate = addedDate,
            ExpiryDate = expiryDate
        };

        await _context.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return refreshToken;
    }

    public async Task<bool?> UpdateUserRefreshTokenAsync(Guid id, Guid userId, string token, string jwtId, bool isUsed, bool isRevoked, DateTime addedDate, DateTime expiryDate)
    {
        var existToken = await _context.Set<RefreshToken>().FirstOrDefaultAsync(x => x.Id == id);
        if (existToken != null)
        {
            existToken.Token = token;
            existToken.JwtId = jwtId;
            existToken.IsUsed = isUsed;
            existToken.IsRevoked = isRevoked;
            existToken.AddedDate = addedDate;
            existToken.ExpiryDate = expiryDate;

            await _context.SaveChangesAsync();
            return true;
        }
        return null;
    }

    public Task<List<RefreshToken>> GeUserRefreshTokensAsync(Guid userId)
    {
        var tokens = _context.Set<RefreshToken>().Where(x => x.UserId == userId).ToListAsync();
        return tokens;
    }
}
