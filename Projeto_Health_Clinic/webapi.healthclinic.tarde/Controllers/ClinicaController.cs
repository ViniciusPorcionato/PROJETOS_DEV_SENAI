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
    
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar uma nova clinica
        /// </summary>
        /// <param name="novaClinica"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]//adm
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

        /// <summary>
        /// Endpoint criado para deletar uma clinica existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        [Authorize(Roles = "Administrador")]//adm
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

        /// <summary>
        /// Endpoint criado para atualizar uma clinica existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="clinica"></param>
        /// <returns></returns>
        [HttpPut("Atualizar")]
        [Authorize(Roles = "Administrador")]//adm
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

        /// <summary>
        /// Endpoint criado para listar todas as clinicas existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar")]
        [Authorize(Roles = "Paciente")]
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

        /// <summary>
        /// Endpoint criado para buscar clinica existente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        [Authorize(Roles = "Administrador")]//adm
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
