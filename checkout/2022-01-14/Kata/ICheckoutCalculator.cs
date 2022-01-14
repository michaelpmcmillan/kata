namespace Kata
{
    public interface ICheckoutCalculator
    {
        int GetTotalPrice(Dictionary<string, int> scannedItems);
    }
}