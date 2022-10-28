using VendingMachineKata.Coin;

namespace VendingMachineKata.ConsoleApp.Parse
{
    public interface IParseConsoleInput
    {
        CoinEnum Parse(string input);
    }
}