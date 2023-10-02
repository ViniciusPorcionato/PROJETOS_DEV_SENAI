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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                return StatusCode(201, novaEspecialidade);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para deletar especialidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para atualizar especialidade existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [HttpPut("Atualizar")]
        public IActionResult Put(Guid Id, Especialidade especialidade)
        {
            try
            {
                Especialidade especialidadeBuscada = _especialidadeRepository.BuscarPorId(especialidade.IdEspecialidade);

                if (especialidadeBuscada != null)
                {
                    try
                    {
                        _especialidadeRepository.Atualizar(Id, especialidade);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Especialidade não encontrada !");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar especialidade por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Especialidade especialidadeBuscada = _especialidadeRepository.BuscarPorId(id);
                if (especialidadeBuscada == null)
                {
                    return NotFound("Especialidade Buscada não encontrada !");
                }

                return StatusCode(200, especialidadeBuscada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
