
namespace eShop.Domain.Interfaces.Services;

public interface IAccountService
{
    Task<ApiResponse<AuthResultResDto>> LoginAsync(UserLoginReqDto dto);
    Task<ApiResponse<AuthResultResDto>> RegisterAsync(UserRegisterReqDto dto);
    Task<ApiResponse<AuthResultResDto>> RefreshTokenAsync(TokenReqDto dto);

}
