using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto dto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(dto);

            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {

            List<ReadFilmeDto> readDto = _filmeService.RecuperarFilmes(classificacaoEtaria);

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
        public IActionResult RecuperarFilmesPorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperarFilmesPorId(id);

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
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto dto)
        {
            Result resultado = _filmeService.AtualizaFilme(id, dto);

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
        public IActionResult DeleteFilme(int id)
        {
            Result resultado = _filmeService.DeleteFilme(id);

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
