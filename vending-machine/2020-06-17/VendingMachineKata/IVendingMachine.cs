using VendingMachineKata.Coin;

namespace VendingMachineKata
{
    public interface IVendingMachine
    {
        void InsertCoin(CoinEnum coin);
        double GetCoinTotal();
    }
}
