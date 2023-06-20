using AutoMapper;
using Hospital.Application.API.Data.EntitiesModel;
using Hospital.Application.API.Model;

namespace Hospital.Application.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterMedicalRecordEntitie, RegisterMedicalRecordModel>().ReverseMap();
            CreateMap<RegisterMedicalRecordEntitie, RegisterMedicalRecordResponse>().ReverseMap();
            CreateMap<RegisterMedicalRecordModel, RegisterMedicalRecordResponse>().ReverseMap();
            CreateMap<RegisterMedicalRecordResponse, UpdateMedicalRecordModel>().ReverseMap();
        }
    }
}
