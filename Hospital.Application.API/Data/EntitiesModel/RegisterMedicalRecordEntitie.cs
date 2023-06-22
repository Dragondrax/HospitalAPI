using Hospital.Application.API.Model;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Application.API.Data.EntitiesModel
{
    public class RegisterMedicalRecordEntitie : Entity
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string? Endereco { get; set; }
        public DateTime Dt_Register { get; set; }
    }
}
