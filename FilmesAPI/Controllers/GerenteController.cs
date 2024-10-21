using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionarGerente(dto);

            return CreatedAtAction(nameof(RecuperarGerentesPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            List<ReadGerenteDto> readDto = _gerenteService.RecuperarGerentes();

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
        public IActionResult RecuperarGerentesPorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperarGerentesPorId(id);

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
        public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto dto)
        {
            Result resultado = _gerenteService.AtualizaGerente(id, dto);

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
        public IActionResult DeleteGerente(int id)
        {
            Result resultado = _gerenteService.DeleteGerente(id);

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
