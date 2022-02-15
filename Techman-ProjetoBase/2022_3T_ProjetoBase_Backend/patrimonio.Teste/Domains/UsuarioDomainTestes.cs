using Patrimonio.Domains;
using System;
using Xunit;

namespace patrimonio.Teste.Domains
{
    
    public class UsuarioDomainTestes
    {
        [Fact] //Descricao
        public void DeveRetornarUsuarioPreenchido()
        {
            
            //Pre-condiçao / Arrange
            
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456";

            //Procedimento / Act

            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            //Resultado esperado / Assert

            Assert.True(resultado);
        }


    }
}
