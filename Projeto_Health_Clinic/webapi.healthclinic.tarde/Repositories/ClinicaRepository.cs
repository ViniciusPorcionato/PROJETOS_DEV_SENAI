using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = _healthClinicContext.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinicaBuscada.CNPJ = clinica.CNPJ;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.HorarioAbertuta = clinica.HorarioAbertuta;
                clinicaBuscada.HorarioFechamento = clinica.HorarioFechamento;

            }

            _healthClinicContext.Clinica.Update(clinicaBuscada!);
            _healthClinicContext.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Clinica.FirstOrDefault(e => e.IdClinica == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthClinicContext.Clinica.Add(clinica);
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
                Clinica clinicaBuscada = _healthClinicContext.Clinica.Find(id)!;

                if (clinicaBuscada != null)
                {
                    _healthClinicContext.Clinica.Remove(clinicaBuscada);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> Listar()
        {
            try
            {
                return _healthClinicContext.Clinica.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
