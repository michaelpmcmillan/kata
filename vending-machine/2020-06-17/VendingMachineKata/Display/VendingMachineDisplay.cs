using VendingMachineKata.Coin;
using VendingMachineKata.CoinRegister;
using VendingMachineKata.Resources;

namespace VendingMachineKata.Display
{
    public class VendingMachineDisplay : IVendingMachineDisplay
    {
        private readonly IDisplayWriter _displayWriter;
        public string Display { get; private set; }

        public VendingMachineDisplay(IDisplayWriter displayWriter)
        {
            _displayWriter = displayWriter;
        }

        public void Update(ICoinCollection coinCollection)
        {
            var coinTotal = coinCollection.GetCoinTotal();

            if (coinTotal == 0)
            {
                Display = Strings.InsertCoin;
            }
            else
            {
                var dollars = ConvertCentsToDollars(coinTotal);
                Display = string.Format(Strings.DisplayCoinTotal, dollars);
            }

            _displayWriter.Write(Display);
        }

        private static double ConvertCentsToDollars(double cents)
        {
            return cents / 100d;
        }
    }
}