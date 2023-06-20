using System.ComponentModel.DataAnnotations;

namespace Hospital.Application.API.Model
{
    public class AlterUserModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Role { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Id { get; set; }
    }
}
