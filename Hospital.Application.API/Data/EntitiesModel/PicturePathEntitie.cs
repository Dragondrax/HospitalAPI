using System.ComponentModel.DataAnnotations;

namespace Hospital.Application.API.Data.EntitiesModel
{
    public class PicturePathEntitie
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Path { get; set; }
    }
}
