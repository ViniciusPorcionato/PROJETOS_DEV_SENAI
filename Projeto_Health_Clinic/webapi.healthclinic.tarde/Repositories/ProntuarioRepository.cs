using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ProntuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Prontuario prontuario)
        {
            Prontuario prontuarioBuscado = _healthClinicContext.Prontuario.Find(id)!;

            if (prontuarioBuscado != null)
            {
                prontuarioBuscado.Descricao = prontuario.Descricao;
                prontuarioBuscado.IdConsulta = prontuario.IdConsulta;
                prontuarioBuscado.IdMedico= prontuario.IdMedico;

            }

            _healthClinicContext.Prontuario.Update(prontuarioBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Prontuario.FirstOrDefault(e => e.IdProntuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Prontuario prontuario)
        {
            try
            {
                _healthClinicContext.Prontuario.Add(prontuario);
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
                Prontuario prontuarioBuscado = _healthClinicContext.Prontuario.Find(id)!;

                if (prontuarioBuscado != null)
                {
                    _healthClinicContext.Prontuario.Remove(prontuarioBuscado);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Prontuario> Listar()
        {
            try
            {
                return _healthClinicContext.Prontuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
