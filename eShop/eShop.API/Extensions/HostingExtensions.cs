
namespace eShop.API.Extensions;
public static class HostingExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, string secretKey)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
         .AddJwtBearer(jwt =>
         {
             var key = Encoding.ASCII.GetBytes(secretKey);
             jwt.SaveToken = true;

             jwt.TokenValidationParameters = new TokenValidationParameters()
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(key),
                 ValidateIssuer = false, //for production should be true 
                 ValidateAudience = false, //for production should be true
                 RequireExpirationTime = false, //for production should be true, needs to be updated when refresh token is added
                 ValidateLifetime = true
             };

         });
        return services;
    }
}
