using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.FluentAPI
{
    public class eCommerceFluentContext : DbContext
    {

        //Conexão sem distinção de ambientes(desenvolvedor X produção)

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = eCommerce; Integrated Security = True;");
        //}

        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Determinando o Nome da tabela/classe
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS"); 

            //Determinando o nome da coluna, atribuindo a qtd de caracteres maximo, colocando um valor padrão para a linha não ficar nula
            modelBuilder.Entity<Usuario>().Property(x => x.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(10).HasDefaultValue("RG-AUSENTE");
        }

    }
}
