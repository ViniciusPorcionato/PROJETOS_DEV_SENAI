﻿using webapi.healthclinic.tarde.Context;
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
                return _healthClinicContext.Consulta.Where(u => u.IdMedico == id).Select(m => new Consulta
                {
                    IdConsulta = m.IdConsulta,
                    Descricao = m.Descricao,
                    DataConsulta = m.DataConsulta,
                    HoraConsulta = m.HoraConsulta,


                    Medico = new Medico
                    {
                        IdMedico = m.IdMedico,
                        CRM = m.Medico!.CRM,
                    },

                    Paciente = new Paciente
                    {
                        IdPaciente = m.IdPaciente,
                        RG = m.Paciente!.RG,
                        
                    },

                    Clinica = new Clinica
                    {
                        IdClinica = m.IdClinica,
                        NomeFantasia = m.Clinica!.NomeFantasia,
                        Endereco = m.Clinica!.Endereco,

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
                return _healthClinicContext.Consulta.Where(u => u.IdPaciente == id).Select(m => new Consulta
                {
                    IdConsulta = m.IdConsulta,
                    Descricao = m.Descricao,
                    DataConsulta = m.DataConsulta,
                    HoraConsulta = m.HoraConsulta,


                    Medico = new Medico
                    {
                        IdMedico = m.IdMedico,
                        CRM = m.Medico!.CRM,
                    },

                    Paciente = new Paciente
                    {
                        IdPaciente = m.IdPaciente,
                        RG = m.Paciente!.RG,

                    },

                    Clinica = new Clinica
                    {
                        IdClinica = m.IdClinica,
                        NomeFantasia = m.Clinica!.NomeFantasia,
                        Endereco = m.Clinica!.Endereco,

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
