namespace VendingMachineKata.Coin
{
    public class CoinFactory : ICoinFactory
    {
        public ICoin Create(CoinEnum coin)
        {
            switch (coin)
            {
                case CoinEnum.Nickle: return new Nickle();
                case CoinEnum.Dime: return new Dime();
                case CoinEnum.Quarter: return new Quarter();
                default: return new InvalidCoin();
            }
        }
    }
}