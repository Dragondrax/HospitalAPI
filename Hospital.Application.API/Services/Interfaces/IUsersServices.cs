using Hospital.Application.API.Model;

namespace Hospital.Application.API.Services.Interfaces
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<bool> SavePictureFile(FormFileModel formFile);
        Task<string> ReturnPictureProfile(string UserId);
    }
}
