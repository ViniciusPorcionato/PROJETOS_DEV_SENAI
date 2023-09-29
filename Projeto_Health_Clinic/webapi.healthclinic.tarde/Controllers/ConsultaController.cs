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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201, novaConsulta);
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
                _consultaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Consulta consulta)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(consulta.IdConsulta);

                if (consultaBuscada != null)
                {
                    try
                    {
                        _consultaRepository.Atualizar(Id, consulta);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                return NotFound("Consulta não encontrada !");

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
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);
                if (consultaBuscada == null)
                {
                    return NotFound("Consulta Buscada não encontrada !");
                }

                return StatusCode(200, consultaBuscada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("PresencaPorIdMedico/{id}")]
        public IActionResult GetByIdDoctor(Guid id)
        {
            try
            {
                List<Consulta> consultaMedicoBuscado = _consultaRepository.ListarConsultasMedico(id);

                if (consultaMedicoBuscado == null)
                {
                    return NotFound("Suas consultas buscadas não foram encontradas !");
                }

                return StatusCode(200, consultaMedicoBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        [HttpGet("PresencaPorIdPaciente/{id}")]
        public IActionResult GetByIdPatient(Guid id)
        {
            try
            {
                List<Consulta> consultaPacienteBuscado = _consultaRepository.ListarConsultasPaciente(id);

                if (consultaPacienteBuscado == null)
                {
                    return NotFound("Suas consultas buscadas não foram encontradas !");
                }

                return StatusCode(200, consultaPacienteBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }
    }
}
