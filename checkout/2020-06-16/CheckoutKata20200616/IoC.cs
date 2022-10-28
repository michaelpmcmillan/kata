using CheckoutKata;
using CheckoutKata.Lookup;
using CheckoutKata.Printing;
using CheckoutKata.Scanning;
using Microsoft.Extensions.DependencyInjection;

namespace CheckoutKata20200616
{
    internal static class IoC
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddTransient<IConsoleApplication, ConsoleApplication>()
                .AddTransient<ICheckout, Checkout>()
                .AddTransient<ICheckoutMessagePrinter, CheckoutMessagePrinter>()
                .AddTransient<IItemLookup, ItemLookup>()
                .AddTransient<IItemScanner, ConsoleItemScanner>()
                .AddTransient<IMessagePrinter, ConsoleMessagePrinter>()
                .BuildServiceProvider();
        }
    }
}
