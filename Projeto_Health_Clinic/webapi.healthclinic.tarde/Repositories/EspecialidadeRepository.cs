using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public EspecialidadeRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Especialidade especialidade)
        {
            Especialidade especialidadeBuscada = _healthClinicContext.Especialidade.Find(id)!;

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.TituloEspecialidade = especialidade.TituloEspecialidade;

            }

            _healthClinicContext.Especialidade.Update(especialidadeBuscada!);
            _healthClinicContext.SaveChanges();
        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                _healthClinicContext.Especialidade.Add(especialidade);
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
                Especialidade especialidadeBuscada = _healthClinicContext.Especialidade.Find(id)!;

                if (especialidadeBuscada != null)
                {
                    _healthClinicContext.Especialidade.Remove(especialidadeBuscada);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
