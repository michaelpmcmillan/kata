namespace Kata
{
    public class CheckoutCalculator : ICheckoutCalculator
    {
        public int GetTotalPrice(Dictionary<string, int> scannedItems)
        {
            int totalCost = 0;
            foreach (var item in scannedItems)
            {
                totalCost += item.Key switch
                {
                    "A" => 50 * item.Value,
                    "B" => 30  * item.Value,
                    "C" => 20  * item.Value,
                    "D" => 15  * item.Value,
                    _ => 0
                };
            }
            return totalCost;
        }
    }
}