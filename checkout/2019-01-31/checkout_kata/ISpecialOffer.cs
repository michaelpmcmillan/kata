using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata
{
    /// <summary>
    /// A special offer that can be applied to a checkout, to 
    ///   reduce the price of a set of items when a set of criteria are met.
    /// </summary>
    public interface ISpecialOffer
    {
        /// <summary>
        /// The number of items that must be bought in for this special offer to be valid.
        /// </summary>
        int NumberOfItemsToQualify { get; }

        /// <summary>
        /// The new discounted price.
        /// </summary>
        decimal DiscountedPrice { get; }

        /// <summary>
        /// The SKU identifier.
        /// </summary>
        string SKU { get; }
    }
}
