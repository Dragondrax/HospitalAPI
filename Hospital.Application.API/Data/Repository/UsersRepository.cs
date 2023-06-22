using Dapper;
using Hospital.Application.API.Data.Context;
using Hospital.Application.API.Data.Repository.Interface;
using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using MySql.Data.MySqlClient;
using Serilog;
using System.Reflection;

namespace Hospital.Application.API.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserResponseModel>> GetUsersAllAsync()
        {
            try
            {
                return await _context.Connection.QueryAsync<UserResponseModel>("SELECT U.Id, UserName, Email, R.Name AS Role FROM hospital.aspnetusers U JOIN hospital.aspnetuserroles UR ON U.Id = UR.UserId JOIN hospital.aspnetroles R ON UR.RoleId = R.Id");
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return null;
            }
        }
    }
}
