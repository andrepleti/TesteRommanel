using FluentValidation;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Repositories;
using TesteRommanel.Domain.Interfaces.Services;

namespace TesteRommanel.Service.Services
{
    public class ClienteService(IRepository<Cliente> baseRepository,
                                     IValidator<Cliente> validator) : IService<Cliente>
    {
        private readonly IRepository<Cliente> _baseRepository = baseRepository;
        private readonly IValidator<Cliente> _validator = validator;

        public List<Cliente> ListarPor(string? nome) => _baseRepository.ListarPor(nome);

        public Cliente ObterPor(long id) => _baseRepository.ObterPor(id);

        public bool VerificarSeExiste(Cliente cliente) => _baseRepository.VerificarSeExiste(cliente);

        public bool Inserir(Cliente cliente)
        {
            Validar(cliente);
            return _baseRepository.Inserir(cliente);
        }

        public bool Atualizar(Cliente cliente)
        {
            Validar(cliente);
            return _baseRepository.Atualizar(cliente);
        }

        public bool Deletar(long id) => _baseRepository.Deletar(id);

        protected void Validar(Cliente cliente)
        {
            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            _validator.ValidateAndThrow(cliente);
        }
    }
}
