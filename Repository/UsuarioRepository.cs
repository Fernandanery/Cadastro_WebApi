using crud_usuario.Data;
using crud_usuario.Models;

namespace crud_usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly usuarioContext context;

        public UsuarioRepository(usuarioContext context)
        {
            this.context = context;
        }

        public async Task<usuario> BuscaUsuarios(int id)
        {
            return await this.context.usuarios.toListAsync();
        }

        public Task<IEnumerable<usuario>> BuscaUsuarios()
        {
            throw new NotImplementedException();
        }
        public void AdicionaUsuario(usuario usuario)
        {
            this.context.Add(usuario);
        }

        public void AtualizaUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }
        public void DeletaUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}