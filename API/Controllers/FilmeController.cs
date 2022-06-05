using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        // acessando o banco e o mapper
        private FilmeContext _context;
        private IMapper _mapper;

        // inciando o contexto e o mapper
        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarFilme(CriarFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto); // Convertendo de filmeDto para Filme

            _context.Filmes.Add(filme); // Adicionando no banco
            _context.SaveChanges();     // salvando mudanças
            return CreatedAtAction(nameof(MostrarUmFilme), new { Id = filme.Id }, filme);

        }

        [HttpGet]
        public IEnumerable<Filme> MostrarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult MostrarUmFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                LendoFilmeDto filmeDto = _mapper.Map<LendoFilmeDto>(filme); // Convertendo de filme para LendoFilmeDto
                filmeDto.HoraDaConsulta = DateTime.Now;

                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, AtualizarFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme); // lendo as informações de filmeDto e colocando em filme
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
