using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        public int IdCliente{ get; set; }

        [Required(ErrorMessage = "O Nome è Obrigatório!")]
        [StringLength(80, MinimumLength = 3)]
        [MinLength(3)]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CEP è Obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Campo Email è Obrigatório!")]
        [EmailAddress(ErrorMessage ="Digite um E-Mail Valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Telefone è Obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Campo Rua è Obrigatório!")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O Campo Bairro è Obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Campo Cidade è Obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Campo Estado è Obrigatório!")]
        public string Estado { get; set; }

        


    }
}