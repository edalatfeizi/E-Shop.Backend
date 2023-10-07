namespace eShop.API.Dtos;

public record AuthResult
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public bool Result { get; set; } = false;
    public List<string> Errors { get; set; } = new List<string>();
}
