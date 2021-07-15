using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        public int IdProdutos { get; set; }

        [Required]
        [StringLength(80,MinimumLength =3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [StringLength(300, MinimumLength = 3)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}