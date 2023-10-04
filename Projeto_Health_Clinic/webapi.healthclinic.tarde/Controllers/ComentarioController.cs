using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository { get; set; }

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar um novo comentario
        /// </summary>
        /// <param name="novoComentario"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Paciente")]
        public IActionResult Post(Comentario novoComentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar comentario existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        [Authorize(Roles = "Paciente")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint criado para atualizar comentario existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="comentario"></param>
        /// <returns></returns>
        [HttpPut("Atualizar")]
        [Authorize(Roles = "Paciente")]
        public IActionResult Put(Guid Id, Comentario comentario)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioRepository.BuscarPorId(comentario.IdComentario);

                if (comentarioBuscado != null)
                {
                    try
                    {
                        _comentarioRepository.Atualizar(Id, comentario);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Comentario não encontrado !");

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para listar comentarios existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                List<Comentario> listaComentarios = _comentarioRepository.Listar();
                return StatusCode(200, listaComentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar comentario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = _comentarioRepository.BuscarPorId(id);
                if (comentarioBuscado == null)
                {
                    return NotFound("Comenatario Buscado não encontrado !");
                }

                return StatusCode(200, comentarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
