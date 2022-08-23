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
        
    }
}