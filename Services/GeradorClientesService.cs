using Bogus;
using Bogus.Extensions.Brazil;
using TesteAtak.Models;

namespace TesteAtak.Services
{
    public class GeradorClientesService
    {
        public List<Clientes> Gerar(int quantidade)
        {
            var faker = new Bogus.Faker<Clientes>("pt_BR")
                .RuleFor(c => c.ClientesID, f => f.Random.Guid())
                .RuleFor(c => c.Nome, f => f.Name.FullName())
                .RuleFor(c => c.Cpf, f => f.Person.Cpf())
                .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumberFormat())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Endereco, f => f.Address.FullAddress())
                .RuleFor(c => c.DataNascimento, f => f.Date.Past(80, DateTime.Today.AddYears(-18)));
            return faker.Generate(quantidade);
        }
    }
}
