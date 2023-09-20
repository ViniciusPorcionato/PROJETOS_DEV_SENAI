using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Endpoint criado para cadastrar nova instituição
        /// </summary>
        /// <param name="novaInstituicao"></param>
        /// <returns></returns>
        [HttpPost("CadastrarInstituicoes")]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(novaInstituicao);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para deletar instituição existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint criado para buscar instituição por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                Instituicao instituicaoBuscado = _instituicaoRepository.BuscarPorId(id);
                if (instituicaoBuscado == null)
                {
                    return NotFound("Instituição Buscada não encontrada !");
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
        /// Endpoint criado para listar todas as instituições cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarInstituicoes")]
        public IActionResult Get()
        {
            try
            {
                List<Instituicao> listaInstituicoes = _instituicaoRepository.Listar();
                return StatusCode(200, listaInstituicoes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint criado para atualizar instituição existente
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(Guid Id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscado = _instituicaoRepository.BuscarPorId(instituicao.IdInstituicao);

                if (instituicaoBuscado != null)
                {
                    try
                    {
                        _instituicaoRepository.Atualizar(Id, instituicao);

                        return StatusCode(200);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                        throw;
                    }
                }

                return NotFound("Instituição não encontrada !");

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
