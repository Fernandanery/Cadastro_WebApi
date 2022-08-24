using crud_usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_usuario.Data
{
    public class usuarioContext : DbContext 
    {
        public usuarioContext(DbContextOptions <usuarioContext> options) : base(options)
        {
        }

        public DbSet<usuario> usuarios {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        //Modificando a tabela no banco de dados
        {
            var usuario = modelBuilder.Entity<usuario>();
            usuario.ToTable("tb_usuario");
            usuario.HasKey(x => x.Id); // Informando que a tabela tem um Id
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

        }
        
    }
}