using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {

        void Cadastrar(TipoUsuario tipoUsuario);
        List<TipoUsuario> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, TipoUsuario tipoUsuario);

    }
}
