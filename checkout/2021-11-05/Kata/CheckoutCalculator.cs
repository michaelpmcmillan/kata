using System;
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
                "A" => CalculateItemAPrice(item.Value),
                "B" => 30 * item.Value,
                "C" => 20 * item.Value,
                "D" => 15 * item.Value,
                _ => 0
            };
        }
        return totalPrice;
    }

    private int CalculateItemAPrice(int itemCount)
    {
        var individualItemPrice = 50;
        var multibuyItemPrice = 130;
        var multibuyCount = 3;
        var completeSpecialOffers = itemCount / multibuyCount;
        var remainingItemCount = itemCount - (completeSpecialOffers * multibuyCount);
        var totalPrice = (multibuyItemPrice * completeSpecialOffers) + remainingItemCount * individualItemPrice;
        return totalPrice;
    }
}