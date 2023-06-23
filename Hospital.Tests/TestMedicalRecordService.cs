using AutoMapper;
using Hospital.Application.API.Data.EntitiesModel;
using Hospital.Application.API.Data.Repository;
using Hospital.Application.API.Data.Repository.Interface;
using Hospital.Application.API.Model;
using Hospital.Application.API.Services;
using Hospital.Application.API.Services.Interfaces;
using Moq;

namespace Hospital.Tests
{
    public class TestMedicalRecordService
    {
        [Fact]
        public async void GetAllAsyncTest()
        {
            //Arrange
            string cpf = "39653679864";

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<RegisterMedicalRecordEntitie, RegisterMedicalRecordModel>(It.IsAny<RegisterMedicalRecordEntitie>())).Returns(new RegisterMedicalRecordModel());

            ResponseServicesModel medicalService = new ResponseServicesModel { Message = "CPF nao encontrado", Object = null };
            RegisterMedicalRecordEntitie medicalEntitie = new RegisterMedicalRecordEntitie();
            IMedicalRecordRepository medicalRecordRepository;
            IMapper mapper;

            var medicalRecordServiceMock = new Mock<IMedicalRecordService>();
            var medicalRecordRepositoryMock = new Mock<IMedicalRecordRepository>();
            var map = new Mock<IMapper>();

            medicalRecordServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(medicalService);
            medicalRecordRepositoryMock.Setup(x => x.GetCpf(cpf)).ReturnsAsync(medicalEntitie);

            var medicalRecordService = new MedicalRecordService(medicalRecordRepositoryMock.Object, mapperMock.Object);

            //Act

            var resultMedicalService = await medicalRecordService.GetAllAsync();

            //Assert

            Assert.Equal(resultMedicalService.Message, "CPF nao encontrado");
        }

        [Fact]
        public async void TestCPFValidatedTrue()
        {
            //Arrange
            string cpf = "39653679864";

            //Act

            var resultCPF = ValidatedValues.ValidatedCPF(cpf);

            //Assert

            Assert.Equal(resultCPF, true);
        }
        [Fact]
        public async void TestCPFValidatedFalse ()
        {
            //Arrange
            string cpf = "39653659864";

            //Act

            var resultCPF = ValidatedValues.ValidatedCPF(cpf);

            //Assert

            Assert.Equal(resultCPF, false);
        }
    }
}