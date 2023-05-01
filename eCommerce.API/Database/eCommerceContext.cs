using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {

        //Conexão sem distinção de ambientes(desenvolvedor X produção)

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = eCommerce; Integrated Security = True;");
        //}

        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nome = "Moda" },
                new Departamento { Id = 2, Nome = "Informática" },
                new Departamento { Id = 3, Nome = "Eletrodomesticos" },
                new Departamento { Id = 4, Nome = "Eletroportáteis" },
                new Departamento { Id = 5, Nome = "Beleza" },
                new Departamento { Id = 6, Nome = "Mercado" },
                new Departamento { Id = 7, Nome = "Móveis" }
                );
        }

    }
}
