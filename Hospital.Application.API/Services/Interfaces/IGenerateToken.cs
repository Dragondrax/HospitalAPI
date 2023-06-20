using Hospital.Application.API.Model;

namespace Hospital.Application.API.Services.Interfaces
{
    public interface IGenerateToken
    {
        Task<LoginResponseModel> GerarJwt(string email);
    }
}
