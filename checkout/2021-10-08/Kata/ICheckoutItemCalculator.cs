using System.Collections.Generic;

namespace Kata
{
    public interface ICheckoutItemCalculator
    {
        float GetTotalPrice(IDictionary<char, int> scannedItems);
    }
}
