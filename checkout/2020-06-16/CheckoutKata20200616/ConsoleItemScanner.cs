using System;
using CheckoutKata.Scanning;

namespace CheckoutKata20200616
{
    public class ConsoleItemScanner : IItemScanner
    {
        public char Scan()
        {
            return Console.ReadKey()
                .Key
                .ToString()
                .ToUpper()
                .ToCharArray()[0];
        }
    }
}