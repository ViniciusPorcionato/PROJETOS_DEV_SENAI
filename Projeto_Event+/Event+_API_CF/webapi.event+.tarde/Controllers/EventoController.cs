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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; }

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar novo evento
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost("CadastrarEvento")]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar evento existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar evento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);
                if (eventoBuscado == null)
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
        /// Endpoint criado para listar eventos existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarEvento")]
        public IActionResult Get()
        {
            try
            {
                List<Evento> listaEventos = _eventoRepository.Listar();
                return StatusCode(200, listaEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint para atualizar evento existente pelo id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(evento.IdEvento);

                if (eventoBuscado != null)
                {
                    try
                    {
                        _eventoRepository.Atualizar(Id, evento);

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
