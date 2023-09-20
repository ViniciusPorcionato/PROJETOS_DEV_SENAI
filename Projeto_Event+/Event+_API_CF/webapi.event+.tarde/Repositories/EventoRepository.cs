using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.IdEvento = evento.IdTipoEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    
                }

                _eventContext.Evento.Update(eventoBuscado!);
                _eventContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);
                _eventContext.SaveChanges();
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
                Evento eventoBuscado = _eventContext.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _eventContext.Evento.Remove(eventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _eventContext.Evento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
