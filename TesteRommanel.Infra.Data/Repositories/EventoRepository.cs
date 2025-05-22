using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Repositories;
using TesteRommanel.Infra.Data.Context;

namespace TesteRommanel.Infra.Data.Repositories
{
    public class EventoRepository(DataBaseContext db) : IEventoRepository<IEvento>
    {
        protected readonly DataBaseContext _db = db;

        public void Inserir(long clienteId, List<IEvento> eventos)
        {
            foreach (var evento in eventos)
            {
                Evento eventEntity = new Evento
                {
                    ClienteId = clienteId,
                    TipoEntidade = "Cliente",
                    TipoEvento = evento.GetType().Name,
                    Dados = JsonSerializer.Serialize(evento),
                    Data = evento.Data
                };

                _db.Entry(evento).State = EntityState.Added;
            }

            _db.SaveChanges();
        }

        public List<IEvento> RetornarEventos(long clienteId)
        {
            var lista = _db.Set<Evento>()
                .Where(e => e.ClienteId == clienteId)
                .OrderBy(e => e.Data)
                .ToList();

            var eventos = new List<IEvento>();

            foreach (var item in lista)
            {
                var type = Type.GetType($"MyApp.Domain.Events.{item.TipoEvento}");
                if (type == null) continue;

                var evento = (IEvento)JsonSerializer.Deserialize(item.Dados, type)!;
                if (evento != null)
                {
                    eventos.Add(evento);
                }
            }

            return eventos;
        }
    }
}
