using api.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cliente_Endereco> Clientes_Enderecos { get; set; }

        public DbSet<Endereco_Tipo> Endereco_Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=marcelo;database=saas");
        }
    }
}
