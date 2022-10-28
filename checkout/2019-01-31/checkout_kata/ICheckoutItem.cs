using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata
{
    /// <summary>
    /// An item that can be added to a checkout, and bought.
    /// </summary>
    public interface ICheckoutItem
    {
        /// <summary>
        /// The SKU identifier for this item.
        /// </summary>
        string SKU { get; }

        /// <summary>
        /// The price of this item.
        /// </summary>
        decimal Price { get; }
    }
}
