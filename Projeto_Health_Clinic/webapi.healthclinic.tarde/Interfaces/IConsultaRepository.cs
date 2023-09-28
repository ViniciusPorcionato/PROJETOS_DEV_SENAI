using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        void Deletar(Guid id);
        void Atualizar(Guid id, Consulta consulta);
        Consulta BuscarPorId(Guid id);
    }
}
