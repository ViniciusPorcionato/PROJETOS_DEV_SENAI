using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        void Deletar(Guid id);
        void Atualizar(Guid id, Clinica clinica);
        List<Clinica> Listar();
        Clinica BuscarPorId(Guid id);

    }
}
