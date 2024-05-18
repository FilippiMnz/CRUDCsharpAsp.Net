using Microsoft.EntityFrameworkCore;

namespace AgroCityCr.Models
{
    public class Database : DbContext
    {
        public DbSet<Fornecedores> Fornecedores {get; set;}
        public DbSet<Produtos> Produtos { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Agrocity;Integrated Security=True");
        }
    }
}
