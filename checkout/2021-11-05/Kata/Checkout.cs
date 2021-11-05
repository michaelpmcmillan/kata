using System;
using System.Collections.Generic;

namespace Kata
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _scannedItems = new();

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach(var scannedItem in _scannedItems)
            {
                totalPrice += scannedItem.Key switch
                {
                    "A" => 50 * scannedItem.Value,
                    "B" => 30 * scannedItem.Value,
                    "C" => 20 * scannedItem.Value,
                    "D" => 15 * scannedItem.Value,
                    _ => 0
                };
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            if(!_scannedItems.ContainsKey(item))
            {
                _scannedItems[item] = 0;
            }
            _scannedItems[item]++;
        }
    }
}
