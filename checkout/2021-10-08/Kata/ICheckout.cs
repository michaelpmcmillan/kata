using System;

namespace Kata
{
    public interface ICheckout
    {
        float GetTotalPrice();
        void Scan(string sku);
    }
}
