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
    public class CheckoutItem : ICheckoutItem
    {
        /// <summary>
        /// Constructs and initialises a new instance of CheckoutItem.
        /// </summary>
        /// <param name="sku">The sku identifier for the item</param>
        /// <param name="price">The price of the item</param>
        public CheckoutItem(string sku, decimal price)
        {
            this._price = price;
            this._sku = sku;
        }

        /// <summary>
        /// The SKU identifier for this item.
        /// </summary>
        public string SKU
        {
            get { return _sku; }
        }

        /// <summary>
        /// The price of this item.
        /// </summary>
        public decimal Price
        {
            get { return _price; }
        }

        private decimal _price;
        private string _sku;

        #region Object Overrides

        /// <summary>
        /// Checks that this instance's SKU matches the given instance's SKU
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return SKU.Equals(((CheckoutItem)obj).SKU);
        }

        /// <summary>
        /// Returns the hashcode of the SKU
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return SKU.GetHashCode();
        }

        #endregion
    }
}
