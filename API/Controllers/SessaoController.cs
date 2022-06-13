using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionarSessao(sessaoDto);
            return CreatedAtAction(nameof(MostrarSessaoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult MostrarSessaoPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.MostrarSessaoPorId(id);
            if (readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }

    }
}
