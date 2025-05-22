using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Factories;

namespace TesteRommanel.Domain.Factories
{
    public class ClienteFactory : IFactory
    {
        public Cliente Recriar(List<IEvento> eventos)
        {
            var cliente = new Cliente();

            foreach (var evento in eventos)
            {
                cliente.Aplicar(evento);
            }

            return cliente;
        }
    }
}
