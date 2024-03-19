using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Interfaces;
using ImpuestosInternosBackEnd.Utilities.Static;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace ImpuestosInternosBackEnd.Test.ComprobantesFiscales
{
    public class ComprobantesFiscalesApplicationTest
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
            var context = scope!.ServiceProvider.GetService<IComprobantesFiscalesApplication>();

            //Arrage 
            //Properties
            var rncCedula = "";
            var Ncf = "";
            var monto = 0;
            var expected = ReplayMessage.MESSAGE_VALIDATE;

            //Act
            var result = await context!.RegisterComprobanteFiscal(new ComprobantesFiscalesRequestDto()
            {
                RncCedula = rncCedula,
                Ncf = Ncf,
                Monto = monto
            }); ;

            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task RegisterComprobantesFiscales__WhenSendingCorrectValue()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope!.ServiceProvider.GetService<IComprobantesFiscalesApplication>();

            //Arrage 
            //Properties
            var rncCedula = "40233979984";
            var Ncf = "E310000000002";
            var monto = 1000.00m;
            var expected = ReplayMessage.MESSAGE_SAVE;

            //Act
            var result = await context!.RegisterComprobanteFiscal(new ComprobantesFiscalesRequestDto()
            {
                RncCedula = rncCedula,
                Ncf = Ncf,
                Monto = monto
            }); ;

            var current = result.Message;
            //Assert
            Assert.AreEqual(expected, current);
        }
    }
}
