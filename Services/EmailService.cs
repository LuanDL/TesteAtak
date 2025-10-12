using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace TesteAtak.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task EnviarComAnexoAsync(string destinatario, byte[] arquivo, string nomeArquivo)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("Sistema", _config["Email:Remetente"]));
            mensagem.To.Add(new MailboxAddress("", destinatario));
            mensagem.Subject = "Clientes Gerados";

            var builder = new BodyBuilder
            {
                TextBody = "Segue planilha gerada com clientes aleatórios"
            };

            builder.Attachments.Add(nomeArquivo, arquivo, new ContentType("application", "vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
            mensagem.Body = builder.ToMessageBody();

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync(_config["Email:smtp"], int.Parse(_config["Email:Porta"]), SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_config["Email:Usuario"], _config["Email:Senha"]);
            await client.SendAsync(mensagem);
            await client.DisconnectAsync(true);

        }
    }
}
