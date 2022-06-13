using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        // acessando o banco e o mapper
        private AppDbContext _context;
        private IMapper _mapper;

        // inciando o contexto e o mapper
        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionarFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto); // Convertendo de filmeDto para Filme

            _context.Filmes.Add(filme); // Adicionando no banco
            _context.SaveChanges();     // salvando mudanças

            return _mapper.Map<ReadFilmeDto>(filmeDto);
        }

        public List<ReadFilmeDto> MostrarFilme(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.
                Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                return _mapper.Map<List<ReadFilmeDto>>(filmes);
            }
            return null;
        }

        public ReadFilmeDto MostrarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme); // Convertendo de filme para LendoFilmeDto
                filmeDto.HoraDaConsulta = DateTime.Now;

                return filmeDto;
            }
            return null;
        }

        public Result AtualizarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado!");
            }
            _mapper.Map(filmeDto, filme); // lendo as informações de filmeDto e colocando em filme
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado!");
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
