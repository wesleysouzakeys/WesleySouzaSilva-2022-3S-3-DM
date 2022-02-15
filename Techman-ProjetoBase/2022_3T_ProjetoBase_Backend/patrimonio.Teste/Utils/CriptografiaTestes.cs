using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace patrimonio.Teste.Utils
{
    public class CriptografiaTestes
    {
        [Fact]
        public void DeveRetornarHashEmBcrypt()
        {
            //Pre-condicao / Arrange

            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            //Procedimento / Act

            var retorno = regex.IsMatch(senha);

            //Resultado esperado / Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DeveRetornarComparacaoValida()
        {
            //Pre-condicao / Arrange

            var senha = "123456789";
            var hash = "$2a$11$sif4PbvlxWNq9fyhZDP7wOXSXVwWkl6nzFmMqWh5b8AktxD77M5Yy";

            //Procedimento / Act

            var comparacao = Criptografia.Comparar(senha, hash);

            //Resultado esperado / Assert
            Assert.True(comparacao);
        }

    }
}
