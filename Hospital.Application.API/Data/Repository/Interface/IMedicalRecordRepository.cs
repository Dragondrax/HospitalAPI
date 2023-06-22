using Hospital.Application.API.Data.EntitiesModel;
using Hospital.Application.API.Model;

namespace Hospital.Application.API.Data.Repository.Interface
{
    public interface IMedicalRecordRepository : IRepository<RegisterMedicalRecordEntitie>
    {
        Task<RegisterMedicalRecordEntitie> GetCpf(string CPF);
    }
}
