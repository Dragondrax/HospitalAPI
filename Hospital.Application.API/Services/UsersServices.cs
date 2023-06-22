using Hospital.Application.API.Data.Repository.Interface;
using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using Hospital.Application.API.Services.Interfaces;
using Serilog;
using System.Reflection;

namespace Hospital.Application.API.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            try
            {
                return await _usersRepository.GetUsersAllAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return null;
            }
        }
    }
}
