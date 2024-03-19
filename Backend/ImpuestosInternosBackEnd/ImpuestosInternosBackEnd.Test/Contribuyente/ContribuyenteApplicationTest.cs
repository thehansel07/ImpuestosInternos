using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Interfaces;
using ImpuestosInternosBackEnd.Utilities.Static;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace ImpuestosInternosBackEnd.Test.Contribuyente
{
    [TestClass]
    public class ContribuyenteApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegisterContribuyentes_WhenSendingNullValuesOrEmpty()
        {
            using var scope = _scopeFactory?.CreateScope();

            var context = scope!.ServiceProvider.GetService<IContribuyenteApplication>();

            //Arrage 

            //Properties
            var rncCedula = "";
            var nombre = "";
            var tipo = "";
            var estatus = true;
            var expected = ReplayMessage.MESSAGE_VALIDATE;


            //Act
            var result = await context!.RegisterContribuyentes(new ContribuyenteRequestDto()
            {
                RncCedula = rncCedula,
                Nombre = nombre,
                Tipo = tipo,
                Estatus = estatus
            });

            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);

        }


        [TestMethod]
        public async Task RegisterContribuyentes_WhenSendingCorrectValue()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope!.ServiceProvider.GetService<IContribuyenteApplication>();

            //Arrage 

            //Properties
            var rncCedula = "4023397998";
            var nombre = "Pedro";
            var tipo = "Persona Fisica";
            var estatus = true;
            var expected = ReplayMessage.MESSAGE_SAVE;


            //Act
            var result = await context!.RegisterContribuyentes(new ContribuyenteRequestDto()
            {
                RncCedula = rncCedula,
                Nombre = nombre,
                Tipo = tipo,
                Estatus = estatus
            });

            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }
    }
}
