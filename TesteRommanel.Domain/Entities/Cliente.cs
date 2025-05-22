namespace TesteRommanel.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            NomeRazaoSocial = string.Empty;
            CpfCnpj = string.Empty;
            InscricaoEstadual = string.Empty;
            Isento = false;
            DataNascimento = null;
            Telefone = string.Empty;
            Email = string.Empty;
            Tipo = (byte)ETipoPessoa.Fisica;
            Cep = string.Empty;
            Logradouro = string.Empty;
            Numero = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;

        }

        public Cliente(string cpfCnpj, long id)
        {
            NomeRazaoSocial = string.Empty;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = string.Empty;
            Isento = false;
            DataNascimento = null;
            Telefone = string.Empty;
            Email = string.Empty;
            Tipo = (byte)ETipoPessoa.Fisica;
            Cep = string.Empty;
            Logradouro = string.Empty;
            Numero = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Id = id;

        }

        public Cliente(EStatus status, long id)
        {
            NomeRazaoSocial = string.Empty;
            CpfCnpj = string.Empty;
            InscricaoEstadual = string.Empty;
            Isento = false;
            DataNascimento = null;
            Telefone = string.Empty;
            Email = string.Empty;
            Tipo = (byte)ETipoPessoa.Fisica;
            Cep = string.Empty;
            Logradouro = string.Empty;
            Numero = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Id = id;
            Status = (byte)status;
        }

        public Cliente(string nomeRazaoSocial, string cpfCnpj, string inscricaoEstadual, bool isento, DateTime? dataNascimento, string telefone, string email, byte tipo,
                       string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            NomeRazaoSocial = nomeRazaoSocial;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            Isento = isento;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Tipo = tipo;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Id = 0;
        }

        public Cliente(string nomeRazaoSocial, string cpfCnpj, string inscricaoEstadual, bool isento, DateTime? dataNascimento, string telefone, string email, byte tipo,
                       string cep, string logradouro, string numero, string bairro, string cidade, string estado, long id)
        {
            NomeRazaoSocial = nomeRazaoSocial;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            Isento = isento;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Tipo = tipo;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Id = id;
        }

        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public byte Tipo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public enum ETipoPessoa
        {
            Fisica = 1,
            Juridica = 2
        }
    }
}
