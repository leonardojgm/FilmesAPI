using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionarSessao(dto);

            return CreatedAtAction(nameof(RecuperarSessoesPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            List<ReadSessaoDto> readDto = _sessaoService.RecuperarSessoes();

            if (readDto != null)
            {
                return Ok(readDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessoesPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperarSessoesPorId(id);

            if (readDto != null)
            {
                return Ok(readDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto dto)
        {
            Result resultado = _sessaoService.AtualizaSessao(id, dto);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao(int id)
        {
            Result resultado = _sessaoService.DeleteSessao(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
