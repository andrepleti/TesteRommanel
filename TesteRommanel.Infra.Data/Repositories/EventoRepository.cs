using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Repositories;
using TesteRommanel.Infra.Data.Context;

namespace TesteRommanel.Infra.Data.Repositories
{
    public class EventoRepository(DataBaseContext db) : IEventoRepository<Evento>
    {
        protected readonly DataBaseContext _db = db;

        public void Inserir(string tipo, Cliente cliente)
        {
            Evento evento = new Evento
            {
                ClienteId = cliente.Id,
                TipoEntidade = "Cliente",
                TipoEvento = tipo,
                Dados = JsonSerializer.Serialize(cliente),
                Data = DateTime.Now
            };

            _db.Entry(evento).State = EntityState.Added;

            _db.SaveChanges();
        }

        public List<Evento> RetornarEventos(long clienteId)
        {
            return _db.Set<Evento>()
                .Where(e => e.ClienteId == clienteId)
                .OrderBy(e => e.Data)
                .ToList();
        }
    }
}
