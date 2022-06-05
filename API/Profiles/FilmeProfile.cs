using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {

        public FilmeProfile()
        {
            CreateMap<CriarFilmeDto, Filme>();
            CreateMap<Filme, LendoFilmeDto>();
            CreateMap<AtualizarFilmeDto, Filme>();
        }
    }
}
