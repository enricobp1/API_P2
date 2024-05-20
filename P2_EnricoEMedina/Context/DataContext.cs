using Microsoft.EntityFrameworkCore;
using P2_EnricoEMedina.Model;

namespace P2_EnricoEMedina.Context
{

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=P2_EnricoEMedinaDB;ConnectRetryCount=0");
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set;}

    }
}
