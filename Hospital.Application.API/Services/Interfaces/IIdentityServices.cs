namespace Hospital.Application.API.Services.Interfaces
{
    public interface IIdentityServices
    {
        Task<bool> CreateRolesAsync();
    }
}
