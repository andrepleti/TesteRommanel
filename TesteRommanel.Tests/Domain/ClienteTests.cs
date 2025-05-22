using TesteRommanel.Domain.Entities;
using static TesteRommanel.Domain.Entities.Cliente;

namespace TesteRommanel.Tests.Domain
{
    public class ClienteTests
    {
        [Fact]
        public void CriarClienteComIdECpfCnpj()
        {
            Cliente cliente = new("00993564062", 1);

            Assert.Equal("00993564062", cliente.CpfCnpj);
            Assert.Equal(1, cliente.Id);
        }

        [Fact]
        public void CriarClienteComEndereco()
        {
            Cliente cliente = new("André", "00993564062", string.Empty, false, Convert.ToDateTime("09/04/1990"), "14999999999", 
                                  "andre@email.com", (byte)ETipoPessoa.Fisica, "11111111", "Rua Um", "11", "Centro", "Bauru", "SP", 1);

            Assert.Equal("André", cliente.NomeRazaoSocial);
            Assert.Equal("00993564062", cliente.CpfCnpj);
            Assert.Equal(string.Empty, cliente.InscricaoEstadual);
            Assert.False(cliente.Isento);
            Assert.Equal(9, cliente.DataNascimento!.Value.Day);
            Assert.Equal(4, cliente.DataNascimento!.Value.Month);
            Assert.Equal(1990, cliente.DataNascimento!.Value.Year);
            Assert.Equal("14999999999", cliente.Telefone);
            Assert.Equal("andre@email.com", cliente.Email);
            Assert.Equal((byte)ETipoPessoa.Fisica, cliente.Tipo);
            Assert.Equal("11111111", cliente.Cep);
            Assert.Equal("Rua Um", cliente.Logradouro);
            Assert.Equal("11", cliente.Numero);
            Assert.Equal("Centro", cliente.Bairro);
            Assert.Equal("Bauru", cliente.Cidade);
            Assert.Equal("SP", cliente.Estado);
            Assert.Equal(1, cliente.Id);
        }
    }
}
