namespace eShop.API.Dtos.Req;

public class TokenRequestDto
{
    [Required]
    public string Token { get; set; }
    [Required]
    public string RefreshToken { get; set; }
}
