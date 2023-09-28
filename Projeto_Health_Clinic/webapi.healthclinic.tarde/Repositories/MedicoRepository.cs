using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public MedicoRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = _healthClinicContext.Medico.Find(id)!;

            if (medicoBuscado != null)
            {
                medicoBuscado.CRM = medico.CRM;
                medicoBuscado.IdClinica = medico.IdClinica;
                medicoBuscado.IdEspecialidade = medico.IdEspecialidade;
            }

            _healthClinicContext.Medico.Update(medicoBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Medico.FirstOrDefault(e => e.IdMedico == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthClinicContext.Medico.Add(medico);
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
                Medico medicoBuscado = _healthClinicContext.Medico.Find(id)!;

                if (medicoBuscado != null)
                {
                    _healthClinicContext.Medico.Remove(medicoBuscado);
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
