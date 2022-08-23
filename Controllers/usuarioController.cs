using crud_usuario.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_usuario.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class usuarioController : ControllerBase
    {
        //Criando uma classe estatica para retornar uma lista no swagger
        private static List<usuario> Usuarios()
        {
            return new List<usuario> {
                new usuario{Id = 1, Nome = "Lucas", DataNascimento = new DateTime (1991, 12, 05)}
            };

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

         [HttpPost]
        public IActionResult Post(usuario usuario)
        {
            var usuarios = Usuarios ();
            usuarios.Add(usuario);
            return Ok(usuarios);
        }
    }
}