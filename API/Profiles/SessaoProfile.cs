﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HoraDeInicio, opts => opts
                .MapFrom(dto => 
                dto.HoraDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
