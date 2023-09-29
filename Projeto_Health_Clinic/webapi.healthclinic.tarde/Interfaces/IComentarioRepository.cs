using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IComentarioRepository
    {

        void Cadastrar(Comentario comentario);
        void Deletar(Guid id);
        void Atualizar(Guid id, Comentario comentario);
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
    }
}
