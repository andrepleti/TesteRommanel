using FluentValidation;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Domain.Interfaces.Validators;
using static TesteRommanel.Domain.Entities.Cliente;

namespace TesteRommanel.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        private readonly IDocumentoValidator _documentoService;

        public ClienteValidator(IDocumentoValidator documentoService)
        {
            _documentoService = documentoService;

            RuleFor(x => new { x.NomeRazaoSocial, x.Tipo })
                .Must(x => !string.IsNullOrWhiteSpace(x.NomeRazaoSocial))
                .WithMessage(x => x.Tipo == ETipoPessoa.Fisica ? "Preencha o nome." : "Preencha a razão social.");

            RuleFor(x => new { x.NomeRazaoSocial, x.Tipo })
                .Must(x => x.NomeRazaoSocial.Length <= 200)
                .WithMessage(x => x.Tipo == ETipoPessoa.Fisica ? "Nome não deve ultrapassar 200 caracteres." : "Razão Social não deve ultrapassar 200 caracteres.");

            RuleFor(x => new { x.CpfCnpj, x.Tipo })
                .Must(x => !string.IsNullOrWhiteSpace(x.CpfCnpj))
                .WithMessage(x => x.Tipo == ETipoPessoa.Fisica ? "Preencha o cpf." : "Preencha a cnpj.");

            RuleFor(x => new { x.CpfCnpj, x.Tipo })
                .Must(x => (x.Tipo == ETipoPessoa.Fisica && x.CpfCnpj.Length == 11) || (x.Tipo == ETipoPessoa.Juridica && x.CpfCnpj.Length == 14))
                .WithMessage(x => x.Tipo == ETipoPessoa.Fisica ? "CPF deve ter 11 caracteres." : "CNPJ deve ter 14 caracteres.");

            RuleFor(x => new { x.CpfCnpj, x.Tipo })
                .Must(x => (x.Tipo == ETipoPessoa.Fisica && _documentoService.ValidarCpf(x.CpfCnpj)) || (x.Tipo == ETipoPessoa.Juridica && _documentoService.ValidarCnpj(x.CpfCnpj)))
                .WithMessage(x => x.Tipo == ETipoPessoa.Fisica ? "CPF inválido." : "CNPJ inválido.");


            RuleFor(x => new { x.InscricaoEstadual, x.Tipo, x.Isento })
                .Must(x => ((!string.IsNullOrWhiteSpace(x.InscricaoEstadual) || x.Isento) && x.Tipo == ETipoPessoa.Juridica) || x.Tipo == ETipoPessoa.Fisica)
                .WithMessage("Preencha a inscrição estadual ou marque a opção isento.");

            RuleFor(x => new { x.DataNascimento, x.Tipo })
                .Must(x => (x.Tipo == ETipoPessoa.Fisica && x.DataNascimento != null && x.DataNascimento.Value.Date <= DateTime.Now.Date) || x.Tipo == ETipoPessoa.Juridica)
                .WithMessage("Preencha a data de nascimento.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Preencha o telefone.")
                .NotNull().WithMessage("Preencha o telefone.")
                .MaximumLength(11).WithMessage("Telefone não deve ultrapassar 11 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Preencha o e-mail.")
                .NotNull().WithMessage("Preencha o e-mail.")
                .EmailAddress().WithMessage("E-mail em formato inválido.")
                .MaximumLength(50).WithMessage("E-mail não deve ultrapassar 50 caracteres.");

            RuleFor(x => x.Tipo)
                .Must(x => x == ETipoPessoa.Fisica || x == ETipoPessoa.Fisica).WithMessage("Selecione o tipo de cadastro.");


            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("Preencha o cep.")
                .NotNull().WithMessage("Preencha o cep.")
                .MaximumLength(8).WithMessage("CEP não deve ultrapassar 8 caracteres.");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("Preencha o logradouro.")
                .NotNull().WithMessage("Preencha o logradouro.")
                .MaximumLength(200).WithMessage("Logradouro não deve ultrapassar 200 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Preencha o número.")
                .NotNull().WithMessage("Preencha o número.")
                .MaximumLength(5).WithMessage("Número não deve ultrapassar 5 caracteres.");


            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Preencha o bairro.")
                .NotNull().WithMessage("Preencha o bairro.")
                .MaximumLength(200).WithMessage("Bairro não deve ultrapassar 200 caracteres.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Preencha o estado.")
                .NotNull().WithMessage("Preencha o estado.")
                .MaximumLength(2).WithMessage("Estado não deve ultrapassar 2 caracteres.");
        }
    }
}
