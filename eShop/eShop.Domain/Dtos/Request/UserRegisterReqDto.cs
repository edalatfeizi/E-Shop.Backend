

namespace eShop.Domain.Dtos.Request;

public class UserRegisterReqDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}
