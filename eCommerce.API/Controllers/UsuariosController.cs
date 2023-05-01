using eCommerce.API.Repositories;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        //{endereco_site}/api/usuarios

        //READ - CRUD

        //Buscando todos os usuários.
        [HttpGet]
        public IActionResult Get()
        {
            var listaUsuarios = _repository.Get();
            return Ok(listaUsuarios);
        }

        //Buscando um usuário especifico.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _repository.Get(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado!");

            return Ok(usuario);
        }

        //CREATE - CRUD
        [HttpPost]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            _repository.Add(usuario);

            return Ok(usuario);
        }

        //UPDATE - CRUD
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Usuario usuario, int id)
        {
            _repository.Update(usuario);
            return Ok(usuario);
        }

        //DELETE - CRUD
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
