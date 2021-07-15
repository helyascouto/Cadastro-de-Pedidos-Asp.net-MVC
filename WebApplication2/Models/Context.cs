using System.Data.Entity;

namespace WebApplication2.Models
{

    public class Context : DbContext
    {
        public DbSet<Clientes> Cliente { get; set; }

        public DbSet<Produtos> Produto { get; set; }

        public DbSet<Pedidos> Pedido { get; set; }
    }
}