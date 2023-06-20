using Hospital.Application.API.Data.Context;
using Hospital.Application.API.Data.Repository;
using Hospital.Application.API.Data.Repository.Interface;
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
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            return services;
        }
    }
}
