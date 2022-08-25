using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata
{
    /// <summary>
    /// Defines the minimum set of functionality for a checkout to function.
    /// </summary>
    public interface ICheckout
    {
        /// <summary>
        /// A list of items, grouped by the SKU.
        /// </summary>
        CheckOutItemCollection Items { get; }

        /// <summary>
        /// A list of special offers.
        /// </summary>
        List<ISpecialOffer> SpecialOffers { get; }

        /// <summary>
        /// Adds the given <paramref name="checkoutItem"/> to this checkout
        /// </summary>
        /// <param name="checkoutItem">The item to add.</param>
        void AddItem(ICheckoutItem checkoutItem);
        
        /// <summary>
        /// Sum up the values of <see cref="Items"/>
        /// </summary>
        decimal CalculateTotal();

        /// <summary>
        /// Add a special offer to the checkout
        /// </summary>
        /// <param name="specialOffer">The special offer to add</param>
        void AddSpecialOffer(ISpecialOffer specialOffer);
    }
}
