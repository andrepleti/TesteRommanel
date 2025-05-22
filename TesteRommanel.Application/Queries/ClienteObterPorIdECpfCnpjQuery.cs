namespace TesteRommanel.Application.Queries
{
    public class ClienteObterPorIdECpfCnpjQuery(long id, string cpfCnpj)
    {
        public long Id { get; set; } = id;
        public string CpfCnpj { get; set; } = cpfCnpj;
    }
}
