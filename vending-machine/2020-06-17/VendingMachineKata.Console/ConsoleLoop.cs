using VendingMachineKata.Coin;
using VendingMachineKata.ConsoleApp.Parse;

namespace VendingMachineKata.ConsoleApp
{
    public class ConsoleLoop : IConsoleLoop
    {
        private readonly IParseConsoleInput _parseConsoleInput;
        private readonly ICoinFactory _coinFactory;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleLoop(IParseConsoleInput parseConsoleInput, ICoinFactory coinFactory, IVendingMachine vendingMachine)
        {
            _parseConsoleInput = parseConsoleInput;
            _coinFactory = coinFactory;
            _vendingMachine = vendingMachine;
        }

        public void Iterate(string input)
        {
            var coin = _parseConsoleInput.Parse(input);
            _vendingMachine.InsertCoin(coin);
        }
    }

    
}