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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);

                return StatusCode(201, novoMedico);
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
                _medicoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Medico medico)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarPorId(medico.IdMedico);

                if (medicoBuscado != null)
                {
                    try
                    {
                        _medicoRepository.Atualizar(Id, medico);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Médico não encontrado !");

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarPorId(id);
                if (medicoBuscado == null)
                {
                    return NotFound("Médico Buscado não encontrada !");
                }

                return StatusCode(200, medicoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
