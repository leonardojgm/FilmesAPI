using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{

    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Obsolete("MailBoxAddress")]
        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new(destinatario, assunto, usuarioId, code);
            MimeMessage mensagemDeEmail = CriaCorpoDoEmail(mensagem);

            EnviarEmail(mensagemDeEmail);
        }

        [Obsolete("MailBoxAddress")]
        private void EnviarEmail(MimeMessage mensagemDeEmail)
        {
            using SmtpClient client = new();
            try
            {
                client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"), _configuration.GetValue<int>("EmailSettings:Port"), true);

                client.AuthenticationMechanisms.Remove("XOUATH2");

                client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"), _configuration.GetValue<string>("EmailSettings:Password"));

                client.Send(mensagemDeEmail);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);

                client.Dispose();
            }
        }

        [Obsolete("MailBoxAddress")]
        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            MimeMessage mensagemDeEmail = new();

            mensagemDeEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }
    }
}
