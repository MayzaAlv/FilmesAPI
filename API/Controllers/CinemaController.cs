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
    public class CinemaController : ControllerBase
    {
        CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }


        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionarCinema(cinemaDto);
           
            return CreatedAtAction(nameof(MostrarCinemasPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult MostrarCinemas([FromQuery] string nomeDoFilme)
        {
            ReadCinemaDto readDto = _cinemaService.MostrarCinemas(nomeDoFilme);

            if (readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult MostrarCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.MostrarCinemaPorId(id);
            if (readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizarCinema(id, cinemaDto);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result resultado = _cinemaService.DeletarCinema(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
