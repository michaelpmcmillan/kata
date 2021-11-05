using System.Collections.Generic;

namespace Kata
{
    public class CheckoutCalculator
    {
        internal int Sum(Dictionary<string, int> items)
        {
            int totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.Key switch
                {
                    "A" => CalculateItemPrice(50, 130, 3, item.Value),
                    "B" => CalculateItemPrice(30, 45, 2, item.Value),
                    "C" => CalculateItemPrice(20, 20, 1, item.Value),
                    "D" => CalculateItemPrice(15, 15, 1, item.Value),
                    _ => 0
                };
            }
            return totalPrice;
        }

        private int CalculateItemPrice(int individualItemPrice, int multibuyItemPrice, int multibuyCount, int itemCount)
        {
            var completeSpecialOffers = itemCount / multibuyCount;
            var remainingItemCount = itemCount - (completeSpecialOffers * multibuyCount);
            var totalPrice = (multibuyItemPrice * completeSpecialOffers) + remainingItemCount * individualItemPrice;
            return totalPrice;
        }
    }
}