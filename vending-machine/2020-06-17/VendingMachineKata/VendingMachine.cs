using VendingMachineKata.Coin;
using VendingMachineKata.CoinRegister;
using VendingMachineKata.Display;

namespace VendingMachineKata
{
    public class VendingMachine : IVendingMachine
    {
        private readonly ICoinSlot _coinSlot;
        private readonly ICoinReturn _coinReturn;
        private readonly ICoinFactory _coinFactory;
        private readonly IVendingMachineDisplay _vendingMachineDisplay;

        public VendingMachine(ICoinSlot coinSlot, ICoinReturn coinReturn, ICoinFactory coinFactory, IVendingMachineDisplay vendingMachineDisplay)
        {
            _coinSlot = coinSlot;
            _coinReturn = coinReturn;
            _coinFactory = coinFactory;
            _vendingMachineDisplay = vendingMachineDisplay;
        }

        public void InsertCoin(CoinEnum coinValue)
        {
            var coin = _coinFactory.Create(coinValue);

            if (coin is InvalidCoin)
            {
                _coinReturn.AddCoin(coin);
            }
            else
            {
                _coinSlot.AddCoin(coin);
                _vendingMachineDisplay.Update(_coinSlot);
            }
        }

        public double GetCoinTotal()
        {
            return _coinSlot.GetCoinTotal();
        }
    }
}