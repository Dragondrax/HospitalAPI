using Hospital.Application.API.Data.Context;
using Hospital.Application.API.Data.EntitiesModel;
using Hospital.Application.API.Data.Repository.Interface;
using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace Hospital.Application.API.Data.Repository
{
    public class MedicalRecordRepository : Repository<RegisterMedicalRecordEntitie>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(ApplicationDbContext context) : base(context) { }
        public async Task<RegisterMedicalRecordEntitie> GetCpf(string CPF)
        {
            try
            {
                return await Db.Tb_MedicalRecord.FirstOrDefaultAsync(b => b.CPF == CPF);
            }
            catch(Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return null;
            }
        }
    }
}
