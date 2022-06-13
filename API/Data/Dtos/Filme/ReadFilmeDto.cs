using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [StringLength(30)]
        public string Genero { get; set; }
        [Range(1, 200)]
        public double Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
