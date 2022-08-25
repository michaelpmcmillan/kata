using Microsoft.Extensions.DependencyInjection;
using VendingMachineKata.ConsoleApp.Startup;

namespace VendingMachineKata.ConsoleApp
{
    public static class ServiceProviderConfiguration
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .ConfigureIoC()
                .BuildServiceProvider();
        }
    }
}
