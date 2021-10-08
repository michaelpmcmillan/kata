using System.Collections.Generic;

namespace Kata
{
    public class CheckoutItemStore : ICheckoutItemStore
    {
        private readonly Dictionary<char, int> _scannedItems = new();

        public void Scan(char sku)
        {
            if (!_scannedItems.ContainsKey(sku))
            {
                _scannedItems.Add(sku, 1);
            }
            else
            {
                _scannedItems[sku]++;
            }
        }

        public IDictionary<char, int> GetScannedItems()
        {
            return _scannedItems;
        }
    }
}
