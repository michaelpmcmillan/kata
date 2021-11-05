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
                    "A" => CalculateItemAPrice(item.Value),
                    "B" => CalculateItemBPrice(item.Value),
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


        private int CalculateItemBPrice(int itemCount)
        {
            var individualItemPrice = 30;
            var multibuyItemPrice = 45;
            var multibuyCount = 2;
            var completeSpecialOffers = itemCount / multibuyCount;
            var remainingItemCount = itemCount - (completeSpecialOffers * multibuyCount);
            var totalPrice = (multibuyItemPrice * completeSpecialOffers) + remainingItemCount * individualItemPrice;
            return totalPrice;
        }
    }
}