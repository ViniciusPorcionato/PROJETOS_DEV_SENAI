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
    [Authorize(Roles = "Administrador")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar um novo paciente
        /// </summary>
        /// <param name="novoPaciente"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);

                return StatusCode(201, novoPaciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar paciente existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para atualizar paciente existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Paciente paciente)
        {
            try
            {
                Paciente pacienteBuscado = _pacienteRepository.BuscarPorId(paciente.IdPaciente);

                if (pacienteBuscado != null)
                {
                    try
                    {
                        _pacienteRepository.Atualizar(Id, paciente);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Paciente não encontrado !");

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para buscar paciente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = _pacienteRepository.BuscarPorId(id);
                if (pacienteBuscado == null)
                {
                    return NotFound("CLinica Buscada não encontrada !");
                }

                return StatusCode(200, pacienteBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
