using Hospital.Application.API.Extensions;
using Hospital.Application.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Hospital.Application.API.Services
{
    public class IdentityServices : IIdentityServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityServices(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> CreateRolesAsync()
        {
            string[] rolesNames = { "Administrador", "Medico", "Paciente" };
            IdentityResult result;
            foreach (var namesRole in rolesNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                {
                    result = await _roleManager.CreateAsync(new IdentityRole(namesRole));
                }
            }

            return true;
        }
    }
}
