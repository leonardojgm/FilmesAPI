using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto dto)
        {
            ReadEnderecoDto readDto = _enderecoService.AdicionarEndereco(dto);

            return CreatedAtAction(nameof(RecuperarEnderecosPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            List<ReadEnderecoDto> readDto = _enderecoService.RecuperarFilmes();

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
        public IActionResult RecuperarEnderecosPorId(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.RecuperarEnderecosPorId(id);

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
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto dto)
        {
            Result resultado = _enderecoService.AtualizaEndereco(id, dto);

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
        public IActionResult DeleteEndereco(int id)
        {
            Result resultado = _enderecoService.DeleteEndereco(id);

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
