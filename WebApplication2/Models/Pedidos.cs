using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Pedidos")]
    public class Pedidos
    {
        [Key]
        public int IdPedidos { get; set; }

        public Clientes Clientes { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        
        public Produtos Produtos { get; set; }

        [Display(Name = "Produto")]
        public int IdProdutos { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [Display(Name = "Data do Pedido")]
        [Required(ErrorMessage = "mm/dd/yyyy")]
        public DateTime DataPedido { get; set; }
    }
}