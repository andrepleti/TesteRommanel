namespace TesteRommanel.Domain.Interfaces.Validators
{
    public interface IDocumentoValidator
    {
        public bool ValidarCnpj(string cnpj);

        public bool ValidarCpf(string cpf);
    }
}
