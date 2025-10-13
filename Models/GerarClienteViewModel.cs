using System.ComponentModel.DataAnnotations;

namespace TesteAtak.Models
{
    public class GerarClienteViewModel
    {
        [Required]
        [Range(10, 1000)]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe um e-mail válido.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public required string Email { get; set; }
        public required string Acao { get; set; }
    }
}
