using System.ComponentModel.DataAnnotations;

namespace Hospital.Application.API.Model
{
    public class AlterPasswordModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
