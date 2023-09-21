using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaEventoBuscado = _eventContext.PresencaEvento.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    presencaEventoBuscado.Situacao = presencaEvento.Situacao;
                    presencaEventoBuscado.IdEvento = presencaEvento.IdEvento;
                    presencaEventoBuscado.IdUsuario = presencaEvento.IdUsuario;

                }

                _eventContext.PresencaEvento.Update(presencaEventoBuscado!);
                _eventContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.PresencaEvento.FirstOrDefault(e => e.IdPresencaEvento == id)!;

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
                PresencaEvento presencaEventoBuscado = _eventContext.PresencaEvento.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _eventContext.PresencaEvento.Remove(presencaEventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                _eventContext.PresencaEvento.Add(inscricao);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                return _eventContext.PresencaEvento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            try
            {
                return _eventContext.PresencaEvento.Select(p => new PresencaEvento
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,

                    Usuario = new Usuario
                    {
                        IdUsuario = p.IdUsuario,
                        Nome = p.Usuario!.Nome,
                    },

                    Evento = new Evento
                    {
                        IdEvento = p.IdEvento,
                        NomeEvento = p.Evento!.NomeEvento,
                    }
                }).Where(u => u.IdUsuario == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
