using ClosedXML.Excel;
using TesteAtak.Models;

namespace TesteAtak.Services
{
    public class ImportadorClientesService
    {
        public byte[] GerarExcel(List<Clientes> clientes)
        {
            using var workbook = new XLWorkbook();
            var planilha = workbook.Worksheets.Add("Clientes");

            planilha.Cell(1, 1).Value = "ClientesID";
            planilha.Cell(1, 2).Value = "Nome";
            planilha.Cell(1, 3).Value = "Cpf";
            planilha.Cell(1, 4).Value = "Telefone";
            planilha.Cell(1, 5).Value = "Email";
            planilha.Cell(1, 6).Value = "Endereco";
            planilha.Cell(1, 7).Value = "DataNascimento";

            for (int i = 0; i < clientes.Count; i++) 
            {
                var c = clientes[i];
                planilha.Cell(i + 2, 1).Value = c.ClientesID.ToString();
                planilha.Cell(i + 2, 2).Value = c.Nome;
                planilha.Cell(i + 2, 3).Value = c.Cpf;
                planilha.Cell(i + 2, 4).Value = c.Telefone;
                planilha.Cell(i + 2, 5).Value = c.Email;
                planilha.Cell(i + 2, 6).Value = c.Endereco;
                planilha.Cell(i + 2, 7).Value = c.DataNascimento.ToShortDateString();
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();

        }

    }
}
