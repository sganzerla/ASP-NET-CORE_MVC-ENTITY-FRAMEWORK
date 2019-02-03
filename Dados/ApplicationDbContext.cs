using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {

        }
        //mapeando classes
        public DbSet<Categoria> Categorias{get;set;}        
    }
}