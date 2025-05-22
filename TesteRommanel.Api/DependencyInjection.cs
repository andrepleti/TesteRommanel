using FluentValidation;
using TesteRommanel.Application.Commands;
using TesteRommanel.Application.Handlers;
using TesteRommanel.Application.Queries;
using TesteRommanel.Application.Validators;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Factories;
using TesteRommanel.Domain.Interfaces.Events;
using TesteRommanel.Domain.Interfaces.Factories;
using TesteRommanel.Domain.Interfaces.Handlers;
using TesteRommanel.Domain.Interfaces.Repositories;
using TesteRommanel.Domain.Interfaces.Validators;
using TesteRommanel.Infra.CrossCutting.Validators;
using TesteRommanel.Infra.Data.Repositories;

namespace TesteRommanel.Api
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Cliente>, ClienteValidator>();
            services.AddScoped<IRepository<Cliente>, ClienteRepository>();
            services.AddScoped<IDocumentoValidator, DocumentoValidator>();
            services.AddScoped<IDataValidator, DataValidator>();
            services.AddScoped<IEventoRepository<IEvento>, EventoRepository>();
            services.AddScoped<ICommandHandler<ClienteAtualizarCommand>, ClienteAtualizarHandler>();
            services.AddScoped<ICommandHandler<ClienteDeletarCommand>, ClienteDeletarHandler>();
            services.AddScoped<ICommandHandler<ClienteInserirCommand>, ClienteInserirHandler>();
            services.AddScoped<IClienteListarNomeHandler<ClienteListarNomeQuery>, ClienteListarNomeHandler>();
            services.AddScoped<IClienteObterPorIdHandler<ClienteObterPorIdQuery>, ClienteObterPorIdHandler>();
            services.AddScoped<IClienteObterPorIdECpfCnpjHandler<ClienteObterPorIdECpfCnpjQuery>, ClienteObterPorIdECpfCnpjHandler>();
            services.AddScoped<IFactory, ClienteFactory>();
        }
    }
}
