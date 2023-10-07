using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Domain.Models;

public class RefreshTokenDto
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public string JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime ExpiryDate { get; set;}
}
