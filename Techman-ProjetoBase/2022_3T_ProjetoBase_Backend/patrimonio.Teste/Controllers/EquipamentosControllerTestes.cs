using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace patrimonio.Teste.Controllers
{
    public class EquipamentosControllerTestes
    {
        [Fact]
        public void DeveRetornarUmaListaDeUsuarios()
        {
            //Pre-condicao / Arrange

            var lista = new List<Equipamento>();

            var equip1 = new Equipamento();
            equip1.Id = 1;
            equip1.NomePatrimonio = "Agenda";
            equip1.Imagem = "";
            equip1.Descricao = "É uma agenda, de fato";
            equip1.Ativo = true;
            equip1.DataCadastro = DateTime.Now;

            var equip2 = new Equipamento();
            equip2.Id = 2;
            equip2.NomePatrimonio = "Garrafa";
            equip2.Imagem = "";
            equip2.Descricao = "É uma garrafa, de fato";
            equip2.Ativo = false;
            equip2.DataCadastro = DateTime.Now;

            lista.Add(equip1);
            lista.Add(equip2);


            var fakeRepository = new Mock<IEquipamentoRepository>();
            fakeRepository.Setup(e => e.Listar())
                .Returns(lista);

            var controller = new EquipamentosController(fakeRepository.Object);

            //Procedimento / Act

            var resultado = controller.BuscarTodos();

            //Resultado esperado / Assert

            Assert.IsType<OkObjectResult>(resultado);

        }

        [Fact]
        public void DeveRetornarUmEquipamentoPorId()
        {

        }


    }
}
