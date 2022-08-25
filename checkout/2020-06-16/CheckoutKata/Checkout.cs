using CheckoutKata.Item;
using CheckoutKata.Lookup;
using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Printing;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly IItemLookup _itemLookup;
        private readonly ICheckoutMessagePrinter _checkoutMessagePrinter;
        private readonly List<ICheckoutItem> _items = new List<ICheckoutItem>();

        public Checkout(IItemLookup itemLookup, ICheckoutMessagePrinter checkoutMessagePrinter)
        {
            _itemLookup = itemLookup;
            _checkoutMessagePrinter = checkoutMessagePrinter;
        }

        public ICheckoutItem AppendItem(char itemCode)
        {
            var item = _itemLookup.Lookup(itemCode);

            if (item != null)
            {
                _items.Add(item);
                _checkoutMessagePrinter.PrintItemPrice(item);
            }

            return item;
        }

        public decimal GetTotalPrice()
        {
            var totalPrice = _items.Sum(i => i.ItemPrice);
            _items.Clear();
            return totalPrice;
        }
    }
}
