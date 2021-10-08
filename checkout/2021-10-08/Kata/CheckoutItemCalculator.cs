using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class CheckoutItemCalculator : ICheckoutItemCalculator
    {
        public float GetTotalPrice(IDictionary<char, int> scannedItems)
        {
            return scannedItems
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
