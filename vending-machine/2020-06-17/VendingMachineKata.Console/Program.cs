using System;

namespace VendingMachineKata.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderConfiguration.Configure();
            var consoleLoop = (IConsoleLoop)serviceProvider.GetService(typeof(IConsoleLoop));

            do
            {
                var line = Console.ReadLine();
                consoleLoop.Iterate(line);
            } while (true);
        }
    }
}
