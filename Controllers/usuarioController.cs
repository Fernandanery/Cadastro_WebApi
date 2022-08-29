using crud_usuario.Models;
using crud_usuario.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crud_usuario.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class usuarioController : ControllerBase
    {
        private readonly IUsuarioRepository repository;

        public usuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await this.repository.BuscaUsuarios();
            return usuarios.Any()
                ? Ok(usuarios)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuarios = await this.repository.BuscaUsuarios(id);
            return usuarios != null
                ? Ok(usuarios)
                : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(usuario usuario)
        {
            this.repository.AdicionaUsuario(usuario);
            return await this.repository.SaveChangesAsync()
                    ? Ok("Usuario adicionado com sucesso")
                    : BadRequest("Erro ao salvar o usuario");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, usuario usuario)
        {
            var usuarioBanco = await this.repository.BuscaUsuarios(id);
            if (usuarioBanco == null) return NotFound("Usuário não encontrado");

            usuarioBanco.Nome = usuario.Nome ?? usuarioBanco.Nome;
            usuarioBanco.DataNascimento = usuario.DataNascimento != new DateTime()
             ? usuario.DataNascimento : usuarioBanco.DataNascimento;

            this.repository.AtualizaUsuario(usuarioBanco);

            return await this.repository.SaveChangesAsync()
      ? Ok("Usuario atualizado com sucesso")
      : BadRequest("Erro ao atualizar o usuario");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, usuario usuario)
    {
        var usuarioBanco = await this.repository.BuscaUsuarios(id);
        if (usuarioBanco == null) return NotFound("Usuário não encontrado");

        this.repository.DeletaUsuario(usuarioBanco);

        return await this.repository.SaveChangesAsync()
                   ? Ok("Usuario deletado com sucesso")
                   : BadRequest("Erro ao deletar o usuario");

    }

}
}