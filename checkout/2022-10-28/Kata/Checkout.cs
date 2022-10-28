namespace Kata
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _scannedItems = new();
        private readonly ICalculator _calculator;

        public Checkout(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int GetTotal()
        {
            return _calculator.GetPrice(_scannedItems);
        }

        public void Scan(string sku)
        {
            if (!_scannedItems.ContainsKey(sku))
            {
                _scannedItems.Add(sku, 0);
            }
            _scannedItems[sku]++;
        }
    }
}
