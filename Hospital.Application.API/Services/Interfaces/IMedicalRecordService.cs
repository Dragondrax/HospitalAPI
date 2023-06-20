using Hospital.Application.API.Model;

namespace Hospital.Application.API.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<ResponseServicesModel> SaveAsync(RegisterMedicalRecordModel data);
        Task<ResponseServicesModel> GetAllAsync();
        Task<ResponseServicesModel> UpdateAsync(UpdateMedicalRecordModel data);
        Task<ResponseServicesModel> DeleteAsync(Guid Id);
    }
}
