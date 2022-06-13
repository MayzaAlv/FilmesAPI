using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
