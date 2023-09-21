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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar novos tipos de eventos
        /// </summary>
        /// <param name="novoTipoEvento"></param>
        /// <returns></returns>
        [HttpPost("CadastrarTipoEvento")]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipoEvento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar tipos de eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar por id tipos de eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);
                if (tipoEventoBuscado == null)
                {
                    return NotFound("Tipo de evento buscado não encontrada !");
                }

                return StatusCode(200, tipoEventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para listar todos tipos de eventos existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarTipoEvento")]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> listaTiposEventos = _tipoEventoRepository.Listar();
                return StatusCode(200, listaTiposEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para atualizar tipo de evento existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(tipoEvento.IdTipoEvento);

                if (tipoEventoBuscado != null)
                {
                    try
                    {
                        _tipoEventoRepository.Atualizar(Id, tipoEvento);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Tipo de evento não encontrado !");

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
