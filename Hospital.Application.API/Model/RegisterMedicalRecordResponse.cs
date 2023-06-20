namespace Hospital.Application.API.Model
{
    public class RegisterMedicalRecordResponse
    {
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string? Endereco { get; set; }
    }
}
