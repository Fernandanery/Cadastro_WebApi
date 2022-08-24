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
        public IActionResult Post(usuario usuario)
        {
            var usuarios = Usuarios();
            usuarios.Add(usuario);
            return Ok(usuarios);
        }
    }
}