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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository { get; set; }

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Prontuario novoProntuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(novoProntuario);

                return StatusCode(201, novoProntuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Prontuario prontuario)
        {
            try
            {
                Prontuario prontuarioBuscado = _prontuarioRepository.BuscarPorId(prontuario.IdProntuario);

                if (prontuarioBuscado != null)
                {
                    try
                    {
                        _prontuarioRepository.Atualizar(Id, prontuario);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Prontuário não encontrado !");

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                List<Prontuario> listaProntuarios = _prontuarioRepository.Listar();
                return StatusCode(200, listaProntuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Prontuario prontuarioBuscado = _prontuarioRepository.BuscarPorId(id);
                if (prontuarioBuscado == null)
                {
                    return NotFound("CLinica Buscada não encontrada !");
                }

                return StatusCode(200, prontuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
