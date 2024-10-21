using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto dto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionarCinema(dto);

            return CreatedAtAction(nameof(RecuperarCinemasPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperarCinemas(nomeDoFilme);

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
        public IActionResult RecuperarCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperarCinemasPorId(id);

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
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto dto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, dto);

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
        public IActionResult DeleteCinema(int id)
        {
            Result resultado = _cinemaService.DeleteCinema(id);

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
