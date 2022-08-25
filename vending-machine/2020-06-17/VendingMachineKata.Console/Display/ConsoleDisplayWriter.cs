using System;
using VendingMachineKata.Display;

namespace VendingMachineKata.ConsoleApp.Display
{
    public class ConsoleDisplayWriter : IDisplayWriter
    {
        public void Write(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
        }
    }
}
