using Hospital.Application.API.Data.EntitiesModel;
using Hospital.Application.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application.API.Data.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserResponseModel>> GetUsersAllAsync();
    }
}
