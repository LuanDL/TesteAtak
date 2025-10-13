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
            var remetente = _config["Email:Remetente"];
            if (string.IsNullOrEmpty(remetente))
                throw new ArgumentException("O email do remetente não está configurado");
            mensagem.From.Add(new MailboxAddress("Sistema", _config["Email:Remetente"]));
            mensagem.To.Add(new MailboxAddress("", destinatario));
            mensagem.Subject = "TesteAtak - Dados Gerados";

            var builder = new BodyBuilder
            {
                TextBody = "Olá,\r\n\r\n" +
                "Conforme solicitado, segue em anexo a planilha com clientes aleatórios, gerada a partir do projeto TesteAtak, desenvolvido por Luan Dias com ASP.NET Core MVC.\r\n\r\n" +
                "O projeto utiliza bibliotecas como Identity para autenticação de usuários, Bogus para geração de dados fictícios e MailKit para envio de e-mails\r\n\r\n" +
                "Segue também o link para o projeto no GitHub: https://github.com/LuanDL/TesteAtak\r\n\r\n" +
                "Atenciosamente.\r\n" +
                "Luan Dias"

            };

            builder.Attachments.Add(nomeArquivo, arquivo, new ContentType("application", "vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
            mensagem.Body = builder.ToMessageBody();

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync(_config["Email:smtp"], int.Parse(_config["Email:SmtpPort"]), SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync(_config["Email:Remetente"], _config["Email:Senha"]);
            await client.SendAsync(mensagem);
            await client.DisconnectAsync(true);

        }
    }
}
