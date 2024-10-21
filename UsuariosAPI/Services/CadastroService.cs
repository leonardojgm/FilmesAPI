using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;

        private readonly UserManager<CustomIdentityUser> _userManager;

        private readonly EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        [Obsolete("MailBoxAddress")]
        public Result CadastrarUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);
            IdentityResult usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "regular").Result;

            if (resultadoIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                string encondedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, encondedCode);

                return Result.Ok().WithSuccess(code);
            }
            else
            {
                return Result.Fail("Falha ao cadastrar usuário");
            }
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            CustomIdentityUser identityUser = _userManager.Users.FirstOrDefault(usuario => usuario.Id == request.UsuarioId);
            IdentityResult identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Falha ao ativar conta de usuário");
            }
        }
    }
}
