using webapi.healthclinic.tarde.Context;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public TipoUsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _healthClinicContext.TipoUsuario.Add(tipoUsuario);
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
                TipoUsuario tipoUsuarioBuscado = _healthClinicContext.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _healthClinicContext.TipoUsuario.Remove(tipoUsuarioBuscado);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
