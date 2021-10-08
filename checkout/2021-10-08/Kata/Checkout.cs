using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Checkout : ICheckout
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

        public float GetTotalPrice()
        {
            return _scannedItems
                .Sum(sku => GetPriceForSku(sku.Key) * sku.Value);
        }

        private int GetPriceForSku(char sku)
        {
            if(sku == 'A') return 50;
            if(sku == 'B') return 30;
            if(sku == 'C') return 20;
            if(sku == 'D') return 15;
            return 0;
        }
    }
}
