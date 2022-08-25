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
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

        [HttpPost]
        public async Task<IActionResult> Post(usuario usuario)
        {
            this.repository.AdicionaUsuario(usuario);
            return await_repository.SaveChangesAsync()
                    ? Ok("Usuario adicionado com sucesso")
                    : BadRequest("Erro ao salvar o usuario");
        }
    }
}