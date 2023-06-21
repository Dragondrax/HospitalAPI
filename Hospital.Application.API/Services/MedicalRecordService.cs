using AutoMapper;
using Hospital.Application.API.Data.EntitiesModel;
using Hospital.Application.API.Data.Repository.Interface;
using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using Hospital.Application.API.Services.Interfaces;
using Serilog;
using System.Reflection;

namespace Hospital.Application.API.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IMapper _mapper;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _mapper = mapper;
        }

        public async Task<ResponseServicesModel> DeleteAsync(string Id)
        {
            try
            {
                var RegisterMedicalRecord = await _medicalRecordRepository.GetId(Guid.Parse(Id));
                if(RegisterMedicalRecord != null)
                {
                    await _medicalRecordRepository.Remove(RegisterMedicalRecord);
                    return new ResponseServicesModel
                    {
                        Message = "Sucesso",
                        Object = null
                    };
                }

                return new ResponseServicesModel
                {
                    Message = "Id Nao Encontrado",
                    Object = null
                };
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return new ResponseServicesModel
                {
                    Message = ex.Message,
                    Object = null
                };
            }
        }

        public async Task<ResponseServicesModel> GetAllAsync()
        {
            try
            {
                var ResultSearchData = await _medicalRecordRepository.SearchAll();

                if (ResultSearchData != null)
                {
                    return new ResponseServicesModel
                    {
                        Message = "Sucesso",
                        Object = ResultSearchData
                    };
                }

                return new ResponseServicesModel
                {
                    Message = "CPF nao encontrado",
                    Object = null
                };
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return new ResponseServicesModel
                {
                    Message = ex.Message,
                    Object = null
                };
            }
        }

        public async Task<ResponseServicesModel> SaveAsync(RegisterMedicalRecordModel data)
        {
            try
            {
                var dataGetCPF = await _medicalRecordRepository.GetCpf(data.CPF);

                if(dataGetCPF == null)
                {
                    await _medicalRecordRepository.Add(_mapper.Map<RegisterMedicalRecordEntitie>(data));
                    return new ResponseServicesModel
                    {
                        Message = "Sucesso",
                        Object = _mapper.Map<RegisterMedicalRecordResponse>(data)
                    };
                }

                return new ResponseServicesModel
                {
                    Message = "O CPF ja esta registrado no sistema",
                    Object = null
                };
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return new ResponseServicesModel
                {
                    Message = ex.Message,
                    Object = null
                };
            }
        }

        public async Task<ResponseServicesModel> UpdateAsync(UpdateMedicalRecordModel data)
        {
            try
            {
                var dataGetId = await _medicalRecordRepository.GetId(data.Id);
                if( dataGetId != null )
                {
                    dataGetId.FullName = data.FullName;
                    dataGetId.Celular = data.Celular;
                    dataGetId.Endereco = data.Endereco;

                    await _medicalRecordRepository.Update(dataGetId);

                    return new ResponseServicesModel
                    {
                        Message = "Sucesso",
                        Object = _mapper.Map<RegisterMedicalRecordResponse>(data)
                    };
                }

                return new ResponseServicesModel
                {
                    Message = "Id Nao Encontrado",
                    Object = null
                };
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return new ResponseServicesModel
                {
                    Message = ex.Message,
                    Object = null
                };
            }
        }
    }
}
