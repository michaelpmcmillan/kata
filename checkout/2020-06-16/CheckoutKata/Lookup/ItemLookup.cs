using CheckoutKata.Item;

namespace CheckoutKata.Lookup
{
    public class ItemLookup : IItemLookup
    {
        public ICheckoutItem Lookup(char itemCode)
        {
            switch (itemCode)
            {
                case 'A':
                    return new CheckoutItem(itemCode, 50);
                case 'B':
                    return new CheckoutItem(itemCode, 30);
                case 'C':
                    return new CheckoutItem(itemCode, 20);
                case 'D':
                    return new CheckoutItem(itemCode, 15);
                default: 
                    return null;
            }
        }
    }
}