using System.Collections.Generic;

namespace Kata
{
    public interface ICheckoutItemStore
    {
        void Scan(char sku);
        IDictionary<char, int> GetScannedItems();
    }
}
