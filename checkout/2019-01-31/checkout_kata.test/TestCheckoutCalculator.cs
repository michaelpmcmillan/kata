using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata.test
{
    /// <summary>
    /// A set of tests for the CheckoutCalculator class.
    /// </summary>
    [TestClass]
    public class TestCheckoutCalculator
    {
        #region TestSpecialOffersAreApplied

        /// <summary>
        /// Test that special offers are properly applied, and the total is affected accordingly.
        /// </summary>
        /// <remarks>GREEN</remarks>
        [TestMethod]
        public void TestSpecialOffersAreApplied()
        {
            // Arrange
            var calculator = new CheckoutCalculator();
            var items = new CheckOutItemCollection();
            items.Add(new CheckoutItem("B", 30));
            items.Add(new CheckoutItem("A", 50));
            items.Add(new CheckoutItem("B", 30));
            var specialOffers = new List<ISpecialOffer>();
            specialOffers.Add(new MultiBuySpecialOffer(2, "B", 45));

            // Act
            decimal total = calculator.Calculate(items, specialOffers);
            
            // Assert
            Assert.AreEqual(95, total);
        }

        /// <summary>
        /// Test that special offers are properly applied, and the total is affected accordingly.
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        public void TestSpecialOffersAreApplied_WithAdditionalItemsNotCoveredByOffer()
        {
            // Arrange
            var calculator = new CheckoutCalculator();
            var items = new CheckOutItemCollection();
            items.Add(new CheckoutItem("B", 30));
            items.Add(new CheckoutItem("A", 50));
            items.Add(new CheckoutItem("B", 30));
            items.Add(new CheckoutItem("B", 30));
            var specialOffers = new List<ISpecialOffer>();
            specialOffers.Add(new MultiBuySpecialOffer(2, "B", 45));

            // Act
            decimal total = calculator.Calculate(items, specialOffers);

            // Assert
            Assert.AreEqual(125, total);
        }


        /// <summary>
        /// Test that special offers are properly applied, and the total is affected accordingly.
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        public void TestSpecialOffersAreApplied_OfferNotFullyCovered()
        {
            // Arrange
            var calculator = new CheckoutCalculator();
            var items = new CheckOutItemCollection();
            items.Add(new CheckoutItem("B", 30));
            items.Add(new CheckoutItem("A", 50));
            var specialOffers = new List<ISpecialOffer>();
            specialOffers.Add(new MultiBuySpecialOffer(2, "B", 45));

            // Act
            decimal total = calculator.Calculate(items, specialOffers);

            // Assert
            Assert.AreEqual(80, total);
        }

        #endregion
    }
}
