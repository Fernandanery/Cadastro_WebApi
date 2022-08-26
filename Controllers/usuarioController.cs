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
                ?  Ok(usuarios)
                : NoContent() ;
        }

        [HttpPost]
        public async Task<IActionResult> Post(usuario usuario)
        {
            this.repository.AdicionaUsuario(usuario);
            return await this.repository.SaveChangesAsync()
                    ? Ok("Usuario adicionado com sucesso")
                    : BadRequest("Erro ao salvar o usuario");
        }
    }
}