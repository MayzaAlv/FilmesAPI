using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionarFilme(CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionarFilme(filmeDto);
            
            return CreatedAtAction(nameof(MostrarUmFilme), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult MostrarFilme([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = _filmeService.MostrarFilme(classificacaoEtaria);
            if(readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult MostrarUmFilme(int id)
        {
            ReadFilmeDto readDto = _filmeService.MostrarFilmePorId(id);
            if(readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizarFilme(id, filmeDto);
            if(resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result resultado = _filmeService.DeletarFilme(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
