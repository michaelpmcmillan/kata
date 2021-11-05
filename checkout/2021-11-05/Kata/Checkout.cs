using System;

namespace Kata
{
    public class Checkout : ICheckout
    {
        private bool _itemHasBeenScanned = false;

        public int GetTotalPrice()
        {
            return _itemHasBeenScanned ? 50 : 0;
        }

        public void Scan(string item)
        {
            _itemHasBeenScanned = true;
        }
    }
}
