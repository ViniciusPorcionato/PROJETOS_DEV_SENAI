using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IProntuarioRepository
    {

        void Cadastrar(Prontuario prontuario);
        void Deletar(Guid id);
        void Atualizar(Guid id, Prontuario prontuario);
        List<Prontuario> Listar();
        Prontuario BuscarPorId(Guid id);

    }
}
