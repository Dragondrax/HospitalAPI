using Hospital.Application.API.Data;
using Hospital.Application.API.Services;
using Hospital.Application.API.Services.Interfaces;

namespace Hospital.Application.API.Configuration
{
    public static class InjectDependencyConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IGenerateToken, GenarateToken>(); 
            services.AddScoped<IIdentityServices, IdentityServices>();
            return services;
        }
    }
}
