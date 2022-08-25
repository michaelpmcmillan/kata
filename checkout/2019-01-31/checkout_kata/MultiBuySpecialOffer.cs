using System;

namespace checkout_kata
{
    /// <summary>
    /// A special offer that will apply a discount, when a given number of items of the same type are purchased.
    /// </summary>
    public class MultiBuySpecialOffer : ISpecialOffer
    {
        /// <summary>
        /// Constructs and initialised a new instance of MultiBuySpecialOffer
        /// </summary>
        /// <param name="numberToQualify">The number of items that must be bought in for this special offer to be valid.</param>
        /// <param name="sku">The sku identifier.</param>
        /// <param name="discountedPrice">The new discounted price.</param>
        public MultiBuySpecialOffer(int numberToQualify, string sku, decimal discountedPrice)
        {
            this._numberToQualify = numberToQualify;
            this._sku = sku;
            this._discountedPrice = discountedPrice;
        }

        /// <summary>
        /// The number of items that must be bought in for this special offer to be valid.
        /// </summary>
        public int NumberOfItemsToQualify
        {
            get { return _numberToQualify; }
        }

        /// <summary>
        /// The new discounted price.
        /// </summary>
        public decimal DiscountedPrice
        {
            get { return _discountedPrice; }
        }

        /// <summary>
        /// The SKU identifier.
        /// </summary>
        public string SKU
        {
            get { return _sku; }
        }

        private int _numberToQualify;
        private decimal _discountedPrice;
        private string _sku;
    }
}