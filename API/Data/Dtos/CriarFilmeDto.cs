using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CriarFilmeDto
    {
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [StringLength(30)]
        public string Genero { get; set; }
        [Range(1, 200)]
        public double Duracao { get; set; }
    }
}
