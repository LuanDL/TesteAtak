using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteAtak.Models;
using TesteAtak.Services;

namespace TesteAtak.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly GeradorClientesService _gerador;
        private readonly ImportadorClientesService _importador;
        private readonly EmailService _email;

        public ClientesController(GeradorClientesService gerador, ImportadorClientesService importador, EmailService email)
        {
            _gerador = gerador;
            _importador = importador;
            _email = email;
        }

        [HttpGet]
        public IActionResult Gerar() => View();

        [HttpPost]
        public async Task<IActionResult> Gerar(GerarClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var clientes = _gerador.Gerar(model.Quantidade);
            var excelBytes = _importador.GerarExcel(clientes);

            if (model.Acao == "download")
            {
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "clientes.xlsx");
            }
            else if (model.Acao == "email")
            {
                if (string.IsNullOrWhiteSpace(model.Email))
                {
                    ModelState.AddModelError("Email", "O campo de e-mail é obrigatório");
                    return View(model);
                }
                else 
                {
                     await _email.EnviarComAnexoAsync(model.Email, excelBytes, "clientes.xlsx");
                    ViewBag.Mensagem = "Email enviado com sucesso!";
                    return View(model);
                }
            }

            ModelState.AddModelError("", "Ação inválida.");
            return View(model);
        }
    }
}
