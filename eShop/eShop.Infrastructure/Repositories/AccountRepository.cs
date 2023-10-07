
namespace eShop.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly EShopDbContext _dbContext;
    public AccountRepository(EShopDbContext dbContext)
    {

        _dbContext = dbContext;

    }

    public async Task AddNewUserRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId)
    {
        var tokens = await _dbContext.RefreshTokens.Where(x => x.UserId == userId).ToListAsync();
        return tokens;
    }

    public async Task UpdateUserRefreshTokenAsync(RefreshToken refreshToken)
    {
        _dbContext.RefreshTokens.Entry(refreshToken).CurrentValues.SetValues(refreshToken);
        await _dbContext.SaveChangesAsync();
    }
}
