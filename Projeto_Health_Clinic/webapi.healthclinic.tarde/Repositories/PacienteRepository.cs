using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepository()
        {
            _healthClinicContext = new HealthClinicContext();

        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = _healthClinicContext.Paciente.Find(id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.Endereco= paciente.Endereco;
                pacienteBuscado.Telefone= paciente.Telefone;

            }

            _healthClinicContext.Paciente.Update(pacienteBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Paciente.FirstOrDefault(e => e.IdPaciente == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthClinicContext.Paciente.Add(paciente);
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
                Paciente pacienteBuscado = _healthClinicContext.Paciente.Find(id)!;

                if (pacienteBuscado != null)
                {
                    _healthClinicContext.Paciente.Remove(pacienteBuscado);
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
