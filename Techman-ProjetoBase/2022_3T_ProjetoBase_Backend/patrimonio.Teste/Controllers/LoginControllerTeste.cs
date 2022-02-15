using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace patrimonio.Teste.Controllers
{
    public class LoginControllerTeste
    {
        [Fact]
        public void DeveRetornarUmUsuarioInvalido()
        {
            //Pre-condicao / Arrange

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "tsuka@email.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);

            //Procedimento / Act

            var resultado = controller.Login(loginViewModel);

            //Resultado esperado / Assert

            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void DeveRetornarUmUsuarioValido()
        {
            //Pre-condicao / Arrange

            var usuarioFake = new Usuario();
            usuarioFake.Email = "tsuka@email.com";
            usuarioFake.Senha = "$2a$11$sif4PbvlxWNq9fyhZDP7wOXSXVwWkl6nzFmMqWh5b8AktxD77M5Yy";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuarioFake);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "tsuka@email.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);

            //Procedimento / Act

            var resultado = controller.Login(loginViewModel);

            //Resultado esperado / Assert

            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
