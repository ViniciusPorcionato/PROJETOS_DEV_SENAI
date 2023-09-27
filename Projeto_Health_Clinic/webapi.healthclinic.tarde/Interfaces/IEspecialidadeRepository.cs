using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IEspecialidadeRepository
    {

        void Cadastrar(Especialidade especialidade);
        void Deletar(Guid id);
        void Atualizar(Guid id, Especialidade especialidade);
        Especialidade BuscarPorId(Guid id);

    }
}
