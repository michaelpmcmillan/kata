namespace Kata
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _scannedItems = new();
        private readonly ICheckoutCalculator _checkoutCalculator;

        public Checkout(ICheckoutCalculator checkoutCalculator)
        {
            _checkoutCalculator = checkoutCalculator;
        }

        public int GetTotalPrice()
        {
            return _checkoutCalculator.GetTotalPrice(_scannedItems);
        }

        public void Scan(string item)
        {
            if (!_scannedItems.ContainsKey(item))
            {
                _scannedItems.Add(item, 0);
            }
            _scannedItems[item]++;
        }
    }
}
