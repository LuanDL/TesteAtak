# TesteAtak

Projeto desenvolvido por **Luan Dias** como parte do processo seletivo interno para a vaga de desenvolvedor na **Atak Sistemas**.

## 🛠️ Tecnologias Utilizadas

Este projeto foi construído com:

- **ASP.NET Core MVC** — estrutura principal da aplicação web
- **Microsoft Identity** — autenticação e gerenciamento de usuários
- **Bogus** — geração de dados fictícios para simular clientes
- **MailKit** — envio de e-mails com anexos via SMTP

## 🚀 Funcionalidades

- Cadastro e login de usuários com confirmação de e-mail
- Edição de perfil e exclusão de conta
- Geração de planilha Excel com dados fictícios de clientes
- Envio da planilha por e-mail para o endereço informado
- Download direto da planilha gerada

## 📋 Instruções para Teste

1. **Criar uma conta**  
   Acesse a opção **"Cadastrar-se"** no canto superior direito da tela. Preencha os campos solicitados e confirme seu e-mail.

2. **Fazer login**  
   Após o cadastro, acesse o sistema pela opção **"Acessar"** no mesmo local.

3. **Acessar funcionalidades**  
   Após o login, você poderá:

   - Editar sua conta clicando no nome de usuário (canto superior direito)
   - Acessar a rotina **"Gerar Clientes"**

4. **Gerar planilha de clientes**  
   Na tela de geração:
   - Informe a **quantidade de registros** (entre 10 e 1000)
   - Preencha o **e-mail de destino**
   - Escolha entre:
     - **Download Excel** — baixa o arquivo localmente
     - **Enviar por E-mail** — envia o arquivo para o e-mail informado

## 📎 Observações

- O projeto está hospedado no GitHub.
- O código segue boas práticas de segurança, como hash de senhas e validação de entrada.
- Melhorias e sugestões são bem-vindas!

---

**Desenvolvido por Luan Dias.**
