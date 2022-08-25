using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata
{
    /// <summary>
    /// Encapsulates functionality that deals with items in this item collection.
    /// </summary>
    public class CheckOutItemCollection : Dictionary<ICheckoutItem, int>
    {
        /// <summary>
        /// Indexor that retuns an item for the given SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public ICheckoutItem this[string sku]
        {
            get { return this.Keys.FirstOrDefault(item => item.SKU == sku); }
        }

        /// <summary>
        /// Adds an item to this collection.
        /// </summary>
        /// <param name="checkoutItem">The item to add.</param>
        public void Add(ICheckoutItem checkoutItem)
        {
            if (this.ContainsKey(checkoutItem))
            {
                this[checkoutItem]++;
            }
            else
            {
                this.Add(checkoutItem, 1);
            }
        }
    }
}
