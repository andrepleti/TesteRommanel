using TesteRommanel.Domain.Interfaces.Events;

namespace TesteRommanel.Domain.Events
{
    public class ClienteInserirEvento(string nomeRazaoSocial, string cpfCnpj, string inscricaoEstadual, bool isento, DateTime? dataNascimento, string telefone, string email, byte tipo,
           string cep, string logradouro, string numero, string bairro, string cidade, string estado) : IEvento
    {
        public string NomeRazaoSocial { get; set; } = nomeRazaoSocial;
        public string CpfCnpj { get; set; } = cpfCnpj;
        public string InscricaoEstadual { get; set; } = inscricaoEstadual;
        public bool Isento { get; set; } = isento;
        public DateTime? DataNascimento { get; set; } = dataNascimento;
        public string Telefone { get; set; } = telefone;
        public string Email { get; set; } = email;
        public byte Tipo { get; set; } = tipo;
        public string Cep { get; set; } = cep;
        public string Logradouro { get; set; } = logradouro;
        public string Numero { get; set; } = numero;
        public string Bairro { get; set; } = bairro;
        public string Cidade { get; set; } = cidade;
        public string Estado { get; set; } = estado;
        public DateTime Data { get; } = DateTime.Now;
    }
}
