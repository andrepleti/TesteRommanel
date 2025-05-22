namespace TesteRommanel.Application.Queries
{
    public class ClienteListarNomeQuery(string? nomeRazaoSocial)
    {
        public string? NomeRazaoSocial { get; set; } = nomeRazaoSocial;
    }
}
