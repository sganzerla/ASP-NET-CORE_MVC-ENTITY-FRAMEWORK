using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //onera bastante a aplicação 
            optionsBuilder.UseLazyLoadingProxies();
        }

        //permite que fluent API possa alterar propriedades das tabelas geradas por padrão 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definindo chave primaria diferente do padrão Id
            modelBuilder.Entity<Pedido>().HasKey("Numero");
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<Pedido>().Property(p => p.DataPedido).IsRequired()
            .HasDefaultValueSql("getdate()");
        }

        //mapeando classes
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}