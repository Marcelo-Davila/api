using api.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=marcelo;database=saas");
        }
    }
}
