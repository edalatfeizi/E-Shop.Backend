
using eShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = jwtTokenHandler.WriteToken(token);
        var refreshToken = new RefreshToken
        {
            JwtId = token.Id,
            Token = RandomStringGenerator(jwtToken.Length),
            AddedDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6),
            IsRevoked = false,
            IsUsed = false,
            UserId = Guid.Parse(user.Id),
        };

        await _accountService.AddUserRefreshToken(refreshToken);

        var authResult = new AuthResult { Result = true, Token = jwtToken , RefreshToken = refreshToken.Token };
        return authResult;
    }

    private string RandomStringGenerator(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz_";
        
        return new string(Enumerable.Repeat(chars,length).Select(s => s[random.Next(chars.Length)]).ToArray());
    }
}
