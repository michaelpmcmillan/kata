using System.Collections.Generic;

namespace Kata
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _scannedItems = new();
        private readonly CheckoutCalculator _checkoutCalculator;

        public Checkout(CheckoutCalculator checkoutCalculator)
        {
            _checkoutCalculator = checkoutCalculator;
        }

        public int GetTotalPrice()
        {
            return _checkoutCalculator.Sum(_scannedItems);
        }

        public void Scan(string item)
        {
            if (!_scannedItems.ContainsKey(item))
            {
                _scannedItems[item] = 0;
            }
            _scannedItems[item]++;
        }
    }
}
