using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        void Deletar(Guid id);
        void Atualizar(Guid id, Medico medico);
        Medico BuscarPorId(Guid id);

    }
}
