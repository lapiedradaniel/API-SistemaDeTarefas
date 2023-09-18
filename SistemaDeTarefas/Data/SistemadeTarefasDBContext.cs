using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemadeTarefasDBContext : DbContext 
    {
        public SistemadeTarefasDBContext(DbContextOptions<SistemadeTarefasDBContext> options) : base(options)
        {

        }
        // Cria a tabela Usuarios no banco
        public DbSet<UsuarioModel> Usuarios { get; set; }   
        //Cria a tabela Tarefa no banco 
        public DbSet<TarefaModel> Tarefa { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
