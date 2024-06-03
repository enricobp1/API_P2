using Microsoft.EntityFrameworkCore;
using API_P2.Model;

namespace API_P2.Context
{

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=API_P2_DB;ConnectRetryCount=0");
        }

        public DbSet<Entrega> Entrega { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
    }
}