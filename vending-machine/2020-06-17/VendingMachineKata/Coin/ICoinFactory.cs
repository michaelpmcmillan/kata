namespace VendingMachineKata.Coin
{
    public interface ICoinFactory
    {
        ICoin Create(CoinEnum coin);
    }
}
