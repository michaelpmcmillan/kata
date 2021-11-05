using System.Collections.Generic;

public class CheckoutCalculator
{
    internal int Sum(Dictionary<string, int> items)
    {
        int totalPrice = 0;
        foreach (var item in items)
        {
            totalPrice += item.Key switch
            {
                "A" => 50 * item.Value,
                "B" => 30 * item.Value,
                "C" => 20 * item.Value,
                "D" => 15 * item.Value,
                _ => 0
            };
        }
        return totalPrice;
    }
}