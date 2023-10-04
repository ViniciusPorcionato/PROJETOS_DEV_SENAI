using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {

                consultaBuscada.DataConsulta = consulta.DataConsulta;
                consultaBuscada.HoraConsulta = consulta.HoraConsulta;

            }

            _healthClinicContext.Consulta.Update(consultaBuscada!);
            _healthClinicContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Consulta.FirstOrDefault(e => e.IdConsulta == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthClinicContext.Consulta.Add(consulta);
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
                Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

                if (consultaBuscada != null)
                {
                    _healthClinicContext.Consulta.Remove(consultaBuscada);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarConsultasMedico(Guid id)
        {
            try
            {
                return _healthClinicContext.Consulta.Where(u => u.IdMedico == id).Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    Descricao = c.Descricao,
                    DataConsulta = c.DataConsulta,
                    HoraConsulta = c.HoraConsulta,


                    Medico = new Medico
                    {
                        IdMedico = c.IdMedico,
                        CRM = c.Medico!.CRM,
                        Usuario = new Usuario 
                        { 
                            Nome = c.Medico.Usuario!.Nome
                        }
                    },

                    Paciente = new Paciente
                    {
                        IdPaciente = c.IdPaciente,
                        RG = c.Paciente!.RG,
                        Usuario = new Usuario
                        {
                            Nome = c.Paciente.Usuario!.Nome
                        }
                        
                    },

                    Clinica = new Clinica
                    {
                        IdClinica = c.IdClinica,
                        NomeFantasia = c.Clinica!.NomeFantasia,
                        Endereco = c.Clinica!.Endereco,

                    }
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            };
        }

        public List<Consulta> ListarConsultasPaciente(Guid id)
        {
            try
            {
                return _healthClinicContext.Consulta.Where(u => u.IdPaciente == id).Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    Descricao = c.Descricao,
                    DataConsulta = c.DataConsulta,
                    HoraConsulta = c.HoraConsulta,


                    Medico = new Medico
                    {
                        IdMedico = c.IdMedico,
                        CRM = c.Medico!.CRM,
                        Usuario = new Usuario
                        {
                            Nome = c.Medico.Usuario!.Nome
                        }
                    },

                    Paciente = new Paciente
                    {
                        IdPaciente = c.IdPaciente,
                        RG = c.Paciente!.RG,
                        Usuario = new Usuario
                        {
                            Nome = c.Paciente.Usuario!.Nome
                        }

                    },

                    Clinica = new Clinica
                    {
                        IdClinica = c.IdClinica,
                        NomeFantasia = c.Clinica!.NomeFantasia,
                        Endereco = c.Clinica!.Endereco,


                    }
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            };
        }
    }
}
