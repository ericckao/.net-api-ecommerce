using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /*
     * [Table] = Definir o nome da tabela
     * [Collum] = Definir o nome da coluna
     * [NotMapped] = Não mapear uma propriedade
     * [ForeignKey] = Definir que a propriedade é o vinculo da chave estrangeira
     * [InverseProperty] = Defini a referência para cada FK vinda da mesma tabela
     * [DatabaseGenerated] = Definir se uma propriedade vai ou não ser gerenciada pelo banco
     *
     * DataAnnotations
     * [Key] = Definir que a propriedade é uma FK
     * 
     * EF Core
     * [Index] = Definir/Criar Indice no banco (x - Unique)
     * 
     * DataAnnotation, FluentAPI
     * Code-First = Code > > DataBase
     * Database-First = Database -> Code
     * 
     */

    
    //nameof(Email) = "Email"
    [Index(nameof(Email), IsUnique =true, Name = "IX_EMAIL_UNICO")]
    [Index(nameof(Nome), nameof(CPF))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        /*Convenção ID - UsuarioId = PK - Identity
         */
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
 
        /*[Key]
        *[Column("COD")]
        */


        public int Codigo { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

        [Required] //Define que o campo não irá permitir Nulo. (not null)
        [MaxLength(15)] //Tamanho maximo de caracteres permitidos
        public string? Sexo { get; set; }

        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? SituacaoCadastro { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula { get; set; }

        /*Registro Ativo = (SituaçãoCadastro == "ATIVO") ? true : false;
        *Software/Aplicativo - Não Persistido
        */
        [NotMapped]
        public bool RegistroAtivo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //GETDATE()
        public DateTimeOffset DataCadastro { get; set; }

        [ForeignKey("UsuarioId")]
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? Enderecos { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }


        /*
         * PedidosCompradosPeloCliente
         * - ClienteId*
         * - ColaboradorId
         * - SupervisorId
         *
         *  PedidosGerenciadosPeloColaborador
         * - ClienteId
         * - ColaboradorId*
         * - SupervisorId
         * 
         *   PedidosSupervisionadosPeloColaboradorSupervisor
         * - ClienteId
         * - ColaboradorId
         * - SupervisorId*
         *
         *    Usuario.PedidosCompradorPeloCliente[2].IdS
         */



        [InverseProperty("Cliente")]
        public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set;}

        [InverseProperty("Colaborador")]
        public ICollection<Pedido>? PedidosGerenciadoPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]
        public ICollection<Pedido> PedidosSupervisionadosPeloColaboradorSupervisor { get; set; }



    }
}
