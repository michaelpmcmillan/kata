using CheckoutKata.Item;

namespace CheckoutKata.Lookup
{
    public interface IItemLookup
    {
        ICheckoutItem Lookup(char itemCode);
    }
}