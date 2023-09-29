using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ComentarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Comentario comentario)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.Find(id)!;

            if (comentarioBuscado != null)
            {
                comentario.IdConsulta = comentario.IdConsulta;
                comentario.Descricao = comentario.Descricao;

            }

            _healthClinicContext.Comentario.Update(comentarioBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Comentario.FirstOrDefault(e => e.IdComentario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                _healthClinicContext.Comentario.Add(comentario);
                _healthClinicContext.SaveChanges();
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
                Comentario comentarioBuscado = _healthClinicContext.Comentario.Find(id)!;

                if (comentarioBuscado != null)
                {
                    _healthClinicContext.Comentario.Remove(comentarioBuscado);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comentario> Listar()
        {
            try
            {
                return _healthClinicContext.Comentario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
