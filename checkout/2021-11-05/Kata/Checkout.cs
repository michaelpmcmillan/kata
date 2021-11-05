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
                    "A" => 50,
                    "B" => 30,
                    "C" => 20,
                    "D" => 15,
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
        }
    }
}
