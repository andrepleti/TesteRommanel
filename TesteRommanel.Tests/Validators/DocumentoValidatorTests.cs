using TesteRommanel.Infra.CrossCutting.Validators;

namespace TesteRommanel.Tests.Validators
{
    public class DocumentoValidatorTests
    {
        private readonly DocumentoValidator _documentoValidator;

        public DocumentoValidatorTests()
        {
            _documentoValidator = new DocumentoValidator();
        }

        [Fact]
        public void TestarCpfValido()
        {
            bool resultado = _documentoValidator.ValidarCpf("00993564062");
            Assert.True(resultado);
        }

        [Fact]
        public void TestarCpfInvalido()
        {
            bool resultado = _documentoValidator.ValidarCpf("11111111111");
            Assert.False(resultado);
        }

        [Fact]
        public void TestarCnpjValido()
        {
            bool resultado = _documentoValidator.ValidarCnpj("63396077000142");
            Assert.True(resultado);
        }

        [Fact]
        public void TestarCnpjInvalido()
        {
            bool resultado = _documentoValidator.ValidarCnpj("22222222222222");
            Assert.False(resultado);
        }
    }
}
