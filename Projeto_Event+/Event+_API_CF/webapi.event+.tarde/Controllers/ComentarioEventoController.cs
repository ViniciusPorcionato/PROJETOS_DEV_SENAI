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
    public class ComentarioEventoController : ControllerBase
    {

        private IComentarioEventoRepository _comentarioEventoRepository { get; set; }

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar novo comentario
        /// </summary>
        /// <param name="comentarioEvento"></param>
        /// <returns></returns>
        [HttpPost("CadastrarComentario")]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);

                return StatusCode(201);
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
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar comentario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _comentarioEventoRepository.BuscarPorId(id);
                if (comentarioEventoBuscado == null)
                {
                    return NotFound("Comentário de evento buscado não encontrada !");
                }

                return StatusCode(200, comentarioEventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para listar comentarios existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarComentario")]
        public IActionResult Get()
        {
            try
            {
                List<ComentarioEvento> listaComentarios = _comentarioEventoRepository.Listar();

                return StatusCode(200, listaComentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
