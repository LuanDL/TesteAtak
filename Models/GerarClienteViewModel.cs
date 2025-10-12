using System.ComponentModel.DataAnnotations;

namespace TesteAtak.Models
{
    public class GerarClienteViewModel
    {
        [Required]
        [Range(10, 1000)]
        public int Quantidade { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Acao { get; set; }
    }
}
