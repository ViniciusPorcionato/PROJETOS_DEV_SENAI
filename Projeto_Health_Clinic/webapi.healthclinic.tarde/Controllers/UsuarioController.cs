using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar um novo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("CadastrarUsuario")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar usuario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário buscado não encontrado !");
                }

                return StatusCode(200, usuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para buscar usuario pelo email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult GetByEmailEndPassword(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);
                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário buscado não encontrado !");
                }

                return StatusCode(200, usuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
