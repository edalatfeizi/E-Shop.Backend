using Microsoft.Extensions.Options;

namespace eShop.Api.Extentions
{
    public static class CorsExtentions
    {
        public static IServiceCollection AddCorsPolicies(this IServiceCollection services, IConfigurationSection corsSection)
        {
            services.Configure<CorsSettings>(corsSection);
            var corsSettings = corsSection.Get<CorsSettings>();

            services.AddCors(options =>
            {
                foreach (var policy in corsSettings!.Policies)
                {
                    options.AddPolicy(policy.PolicyName, p =>
                    {
                        p.WithOrigins(policy.OriginAddresses)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                }
            });
            return services;
        }

        public static void UseCorsPolicies(this WebApplication app)
        {
            var corsSettings = app.Services.GetRequiredService<IOptions<CorsSettings>>();

            app.UseCors(corsSettings.Value.ActivePolicyName);
        }
    }
}

