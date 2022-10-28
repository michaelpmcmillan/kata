using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata
{
    /// <summary>
    /// Calculates the total price of a given set of items, with the given set of special offers applied, if any.
    /// </summary>
    public class CheckoutCalculator
    {
        /// <summary>
        /// Calculates the total price of a given set of items, with the given set of special offers applied, if any.
        /// </summary>
        /// <param name="items">Set of items</param>
        /// <param name="specialOffers">Set of special offers.</param>
        /// <returns></returns>
        public decimal Calculate(IEnumerable<KeyValuePair<ICheckoutItem, int>> items, IEnumerable<ISpecialOffer> specialOffers)
        {
            decimal total = 0;

            foreach (var entry in items)
            {
                var item = entry.Key;
                var count = entry.Value;

                // get all of the special offers that apply to this SKU
                var allSpecialOffers = specialOffers.Where(specialOffer => specialOffer.SKU == item.SKU);

                // if we have some special offers, then apply them, otherwise do a simple sum.
                if (allSpecialOffers.Any())
                {
                    foreach (var specialOffer in allSpecialOffers)
                    {
                        int numberOfTimesToApplyDiscount = count / specialOffer.NumberOfItemsToQualify;
                        int remainingItems = count % specialOffer.NumberOfItemsToQualify;

                        if (numberOfTimesToApplyDiscount >= 1)
                        {
                            // sum the number of items at the discounted price, plus the items that at regular price.
                            decimal priceOfItems = (numberOfTimesToApplyDiscount * specialOffer.DiscountedPrice)
                                + (remainingItems * item.Price);

                            total += priceOfItems;
                        }
                        else
                        {
                            total += (remainingItems * item.Price);
                        }
                    }
                }
                else
                {
                    total += entry.Value * item.Price;
                }
            }

            return total;
        }
    }
}
