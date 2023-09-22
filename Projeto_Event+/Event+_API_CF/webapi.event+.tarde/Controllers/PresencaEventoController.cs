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
    public class PresencaEventoController : ControllerBase
    {

        private PresencaEventoRepository _presencaEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        /// <summary>
        /// Endpoint criado para atualizar presença de evento existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaEventoBuscado = _presencaEventoRepository.BuscarPorId(presencaEvento.IdPresencaEvento);

                if (presencaEventoBuscado != null)
                {
                    try
                    {
                        _presencaEventoRepository.Atualizar(Id, presencaEvento);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Presença evento não encontrado !");

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para buscar presença evento existente passando Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencaEvento presencaEventoBuscado = _presencaEventoRepository.BuscarPorId(id);
                if (presencaEventoBuscado == null)
                {
                    return NotFound("Presença evento buscado não encontrada !");
                }

                return StatusCode(200, presencaEventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar presença evento existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para se inscrever em um evento
        /// </summary>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPost("InscreverPresenca")]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Inscrever(presencaEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para listar presencas de eventos existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarPresenca")]
        public IActionResult Get()
        {
            try
            {
                List<PresencaEvento> listaPresencas = _presencaEventoRepository.Listar();
                return StatusCode(200, listaPresencas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar presença evento pelo id do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("PresencaPorIdUsuario/{id}")]
        public IActionResult GetByIdUser(Guid id)
        {
            try
            {
                List<PresencaEvento> presencaEventoBuscado = _presencaEventoRepository.ListarMinhas(id);

                if (presencaEventoBuscado == null)
                {
                    return NotFound("Suas presenças buscada não foi encontrada !");
                }

                return StatusCode(200, presencaEventoBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }
    }
}
