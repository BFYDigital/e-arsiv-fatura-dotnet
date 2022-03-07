using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xunit;
using BFY.Fatura.Configuration;

namespace BFY.Fatura.Test
{
    public class FaturaServiceTest
    {
        [Fact]
        public void FaturaService_Should_Get_Token_On_Initialisation()
        {
            var configuration = FaturaServiceConfigurationFactory.Create();
            configuration.Username = "33333320";
            configuration.Password = "1";

            FaturaService faturaService = new (configuration);
            faturaService.GetToken().Wait();

            Assert.NotNull(configuration.Token);
        }
    }
}
