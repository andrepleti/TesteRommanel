using System.Text.Json;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Factories;

namespace TesteRommanel.Domain.Factories
{
    public class ClienteFactory : IFactory
    {
        public Cliente Recriar(List<Evento> eventos)
        {
            var cliente = new Cliente();

            foreach (var evento in eventos.OrderByDescending(x => x.Data))
            {
                cliente = JsonSerializer.Deserialize<Cliente>(evento.Dados)!;
                return cliente;
            }
            
            return cliente;
        }
    }
}
