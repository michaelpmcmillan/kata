using System.Linq;

namespace Kata
{
    public class Checkout : ICheckout
    {
        private readonly ICheckoutItemStore _checkoutItemStore;

        public Checkout(ICheckoutItemStore checkoutItemStore)
        {
            _checkoutItemStore = checkoutItemStore;
        }

        public void Scan(char sku)
        {
            _checkoutItemStore.Scan(sku);
        }

        public float GetTotalPrice()
        {
            return _checkoutItemStore.GetScannedItems()
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
