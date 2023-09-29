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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201, novaClinica);
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
                _clinicaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Clinica clinica)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(clinica.IdClinica);

                if (clinicaBuscada != null)
                {
                    try
                    {
                        _clinicaRepository.Atualizar(Id, clinica);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Clinica não encontrada !");

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
                List<Clinica> listaClinicas = _clinicaRepository.Listar();
                return StatusCode(200, listaClinicas);
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
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);
                if (clinicaBuscada == null)
                {
                    return NotFound("Clinica Buscada não encontrada !");
                }

                return StatusCode(200, clinicaBuscada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
