using Hospital.Application.API.Model;

namespace Hospital.Application.API.Services.Interfaces
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
    }
}
