using crud_usuario.Models;

namespace crud_usuario.Repository
{
    //Criar I.D e interface
    public interface IUsuarioRepository
    {
        Task<IEnumerable<usuario>> BuscaUsuarios();

        Task<usuario> BuscaUsuarios(int id);
        void AdicionaUsuario(usuario usuario);
        void AtualizaUsuario(usuario usuario);
        void DeletaUsuario(usuario usuario);

        Task<bool> SaveChangesAsync();

    }
}