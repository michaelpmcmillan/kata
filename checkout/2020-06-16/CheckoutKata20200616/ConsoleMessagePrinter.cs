using System;
using CheckoutKata.Printing;

namespace CheckoutKata20200616
{
    public class ConsoleMessagePrinter : IMessagePrinter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}