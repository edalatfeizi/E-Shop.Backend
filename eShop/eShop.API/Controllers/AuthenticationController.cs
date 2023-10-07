
namespace eShop.API.Controllers;

[Route("api/v1/[controller]")] //api/v1/authentication
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    //private readonly JwtConfig _jwtConfig;
    public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration, IAccountService accountService, TokenValidationParameters tokenValidationParameters)
    {
        _userManager = userManager;
        _configuration = configuration;
        _accountService = accountService;
        _tokenValidationParameters = tokenValidationParameters;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
    {
        //validate incoming request
        if (ModelState.IsValid)
        {
            //check if user already exist
            var exist_user = await _userManager.FindByEmailAsync(requestDto.Email);
            if (exist_user != null)
            {
                return BadRequest(new AuthResult
                {
                    Result = false,
                    Errors = new List<string>
                    {
                        "Email already exist!"
                    }
                });
            }

            //create the user
            var new_user = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Email
            };

            var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);

            if (is_created.Succeeded == true)
            {
                var authResult = await GenerateJwtToken(new_user);

                return Ok(authResult);
            }
            return BadRequest(new AuthResult
            {
                Result = false,
                Errors = is_created.Errors.Select(e => e.Description).ToList()
            });
        }
        return BadRequest();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto requestDto)
    {
        if (ModelState.IsValid)
        {
            //check user exist
            var exist_user = await _userManager.FindByEmailAsync(requestDto?.Email!);
            if (exist_user is null)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Credentials"
                    }
                });
            var isCorrect = await _userManager.CheckPasswordAsync(exist_user, requestDto!.Password);
            if (!isCorrect)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Credentials"
                    },
                    Result = false
                });
            var authResult = await GenerateJwtToken(exist_user);
            return Ok(authResult);
        }
        return BadRequest(new AuthResult
        {
            Errors = new List<string>
            {
                "Invalid payload"
            },
            Result = false
        });
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequest)
    {

        if (ModelState.IsValid)
        {
            var result = await VerifyAndGenerateToken(tokenRequest);
            if (result is null)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>{
                        "Invalid Tokens."
                    }
                });
            return Ok(result);
        }
        return BadRequest(new AuthResult
        {
            Errors = new List<string>
            {
                "Invalid Parameters."
            }
        });
    }

    private async Task<AuthResult?> VerifyAndGenerateToken(TokenRequestDto tokenRequest)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        try
        {
            _tokenValidationParameters.ValidateLifetime = false; //for testing
            var tokenInVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (result == false)
                    return null;
            }

            var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)!.Value);

            var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expiryDate > DateTime.Now)
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Expired Tokens."
                    }
                };
            var userId = tokenInVerification.Claims.FirstOrDefault(x => x.Type == "Id");
            if (userId == null)
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Tokens."
                    }
                };
            var storedTokens = await _accountService.GetUserRefreshTokensAsync(Guid.Parse(userId.Value));
            var exitRefreshToken = storedTokens.FirstOrDefault(x => x.Token == tokenRequest.RefreshToken);
            if (exitRefreshToken == null || exitRefreshToken.IsUsed || exitRefreshToken.IsRevoked)
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Tokens."
                    }
                };

            var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)!.Value;
            if (exitRefreshToken.JwtId != jti)
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Tokens."
                    }
                };
            if (exitRefreshToken.ExpiryDate < DateTime.UtcNow)
                return new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Expired Tokens."
                    }
                };

            exitRefreshToken.IsUsed = true;
            await _accountService.UpdateUserRefreshTokenAsync(exitRefreshToken.Id, exitRefreshToken.UserId, exitRefreshToken.Token, exitRefreshToken.JwtId, exitRefreshToken.IsUsed, exitRefreshToken.IsRevoked, exitRefreshToken.AddedDate, exitRefreshToken.ExpiryDate);
            var user = await _userManager.FindByIdAsync(exitRefreshToken.UserId.ToString());

            var authResult = await GenerateJwtToken(user!);

            return authResult;
        }
        catch (Exception ex)
        {
            return new AuthResult
            {
                Errors = new List<string>
                    {
                        "Internal Server Error.",
                        ex.Message
                    }
            };
        }
    }

    private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();

        return dateTimeVal;
    }

    private async Task<AuthResult> GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value!);

        //token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id",user.Id),
                new Claim(JwtRegisteredClaimNames.Sub,user.Email!),
                new Claim(JwtRegisteredClaimNames.Email,user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString())
            }),
            Expires = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration.GetSection("JwtConfig:ExpiryTimeFrame").Value!)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = jwtTokenHandler.WriteToken(token);
        var refreshToken = new RefreshTokenDto
        {
            JwtId = token.Id,
            Token = RandomStringGenerator(jwtToken.Length),
            AddedDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6),
            IsRevoked = false,
            IsUsed = false,
            UserId = Guid.Parse(user.Id),
        };

        await _accountService.AddUserRefreshTokenAsync(refreshToken.UserId, refreshToken.Token, refreshToken.JwtId, refreshToken.IsUsed, refreshToken.IsRevoked, refreshToken.AddedDate, refreshToken.ExpiryDate);

        var authResult = new AuthResult { Result = true, Token = jwtToken, RefreshToken = refreshToken.Token };
        return authResult;
    }

    private string RandomStringGenerator(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz_";

        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(chars.Length)]).ToArray());
    }
}
