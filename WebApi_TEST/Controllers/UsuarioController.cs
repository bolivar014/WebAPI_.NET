using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_TEST.Data;
using WebApi_TEST.Models;

namespace WebApi_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        // GET Api/<Controller>
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();
        }

        [HttpGet("{id}")]
        // GET Api/<Controller>/5
        public Usuario Get(int id) 
        {
            return UsuarioData.Obtener(id);
        }

        // POST Api/<Controller>
        [HttpPost]
        public bool Post([FromBody] Usuario objUsuario)
        {
            return UsuarioData.Registrar(objUsuario);
        }

        // PUT Api/<Controller>/5
        public bool Put([FromBody] Usuario objUsuario)
        {
            return UsuarioData.Modificar(objUsuario);
        }

        // DELETE Api/<Controller>/5
        public bool Delete(int id)
        {
            return UsuarioData.Eliminar(id);
        }
    }
}
