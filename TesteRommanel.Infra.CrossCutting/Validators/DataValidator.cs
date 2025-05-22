using TesteRommanel.Domain.Interfaces.Validators;

namespace TesteRommanel.Infra.CrossCutting.Validators
{
    public class DataValidator : IDataValidator
    {
        public bool ValidarMaisDe18Anos(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;
            DateTime dataValida = hoje.AddYears(-18);

            return dataValida.Date >= dataNascimento.Date;
        }
    }
}
