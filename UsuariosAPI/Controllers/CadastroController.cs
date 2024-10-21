using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        public CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [Obsolete("MailBoxAddress")]
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto dto)
        {
            Result resultado = _cadastroService.CadastrarUsuario(dto);

            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
            else
            {
                return Ok(resultado.Successes);
            }
        }

        [HttpGet("/Ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);

            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
            else
            {
                return Ok(resultado.Successes);
            }
        }
    }
}
