using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscado != null)
            {
                instituicaoBuscado.NomeFantasia = instituicao.NomeFantasia;
                instituicaoBuscado.Endereco = instituicao.Endereco;

            }

            _eventContext.Instituicao.Update(instituicaoBuscado!);
            _eventContext.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.Instituicao.FirstOrDefault(e => e.IdInstituicao == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(id)!;

                if (instituicaoBuscado != null)
                {
                    _eventContext.Instituicao.Remove(instituicaoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _eventContext.Instituicao.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
