using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }
            else
            {
                return Ok(resultado.Successes);
            }
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }
            else
            {
                return Ok(resultado.Successes);
            }
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetSenhaUsuario(request);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }
            else
            {
                return Ok(resultado.Successes);
            }
        }
    }
}
