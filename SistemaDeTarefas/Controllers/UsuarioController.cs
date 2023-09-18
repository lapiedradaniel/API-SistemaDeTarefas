using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio )
        {
            _usuarioRepositorio= usuarioRepositorio;
            
        }

        //Buca todos os usuarios
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
           List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        //Busca o usuario por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        //Cadastra o usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
           UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);

            return Ok(usuario);
        }

        //Atualiza o usuario pelo  Id
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel,int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel,id);
            return Ok(usuario);
        }

        //Apaga o usuario pelo Id
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar( int id)
        {
            
            bool apagado = await _usuarioRepositorio.Apagar( id);
            return Ok(apagado);
        }
    }
}
