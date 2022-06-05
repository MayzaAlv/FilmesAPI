using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext // Conexão entre Api e o banco de dados
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt) // recebendo as opções do banco e passando 
        {                                                                   // para o construtor do DbContext
        }

        public DbSet<Filme> Filmes { get; set; } // conjunto de dados do banco 
    }
}
