using VendingMachineKata.Coin;

namespace VendingMachineKata.CoinRegister
{
    public interface ICoinCollection
    {
        void AddCoin(ICoin coin);
        double GetCoinTotal();
    }
}