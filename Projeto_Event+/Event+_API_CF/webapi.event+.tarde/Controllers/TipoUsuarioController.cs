using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]  
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar tipo de usuário existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar tipo de usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                if (tipoUsuarioBuscado == null)
                {
                    return NotFound("Tipo de evento buscado não encontrada !");
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para listar todos tipos de usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarTipoUsuario")]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuario> listaTiposUsuarios = _tipoUsuarioRepository.Listar();
                return StatusCode(200, listaTiposUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para atualizar tipo de usuário existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(tipoUsuario.IdTipoUsuario);

                if (tipoUsuarioBuscado != null)
                {
                    try
                    {
                        _tipoUsuarioRepository.Atualizar(Id, tipoUsuario);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                        throw;
                    }
                }

                return NotFound("Tipo de usuário não encontrado !");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
