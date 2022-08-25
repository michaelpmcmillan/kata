using System.Collections.Generic;
using CheckoutKata.Item;

namespace CheckoutKata
{
    public interface ICheckout
    {
        ICheckoutItem AppendItem(char itemCode);
        decimal GetTotalPrice();
    }
}
