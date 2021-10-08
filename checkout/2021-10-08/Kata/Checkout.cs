using System.Linq;

namespace Kata
{
    public class Checkout : ICheckout
    {
        private readonly ICheckoutItemStore _checkoutItemStore;
        private readonly ICheckoutItemCalculator _checkoutItemCalculator;

        public Checkout(
            ICheckoutItemStore checkoutItemStore,
            ICheckoutItemCalculator checkoutItemCalculator)
        {
            _checkoutItemStore = checkoutItemStore;
            _checkoutItemCalculator = checkoutItemCalculator;
        }

        public void Scan(char sku)
        {
            _checkoutItemStore.Scan(sku);
        }

        public float GetTotalPrice()
        {
            var scannedItems = _checkoutItemStore.GetScannedItems();
            return _checkoutItemCalculator.GetTotalPrice(scannedItems);
        }
    }
}
