using checkout_kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace checkout_kata.test
{
    /// <summary>
    /// A set of tests for the Checkout class.
    /// </summary>
    [TestClass]
    public class TestCheckout
    {
        #region Test_AddItemToCheckout

        /// <summary>
        /// Test that items can be added to a checkout.
        /// </summary>
        /// <remarks>GREEN</remarks>
        [TestMethod]
        public void TestAddItemToCheckout()
        {
            // Arrange
            ICheckout checkout = new Checkout();

            // Act
            checkout.AddItem(new CheckoutItem("A", 50));
            checkout.AddItem(new CheckoutItem("B", 30));

            //Assert
            Assert.AreEqual(2, checkout.Items.Count, "Number of items does not equal 2");
        }
        /// <summary>
        /// Test that null cannot be added to the checkout.
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddItemToCheckout_Null()
        {
            // Arrange
            ICheckout checkout = new Checkout();

            // Act
            checkout.AddItem(null);

            //Assert
            Assert.Fail("ArgumentNullException should have been thrown");
        }

        #endregion

        #region TestCalculateTotalPrice

        /// <summary>
        /// Test that the checkout can sum the prices of the items
        /// </summary>
        /// <remarks>GREEN</remarks>
        [TestMethod]
        public void TestCalculateTotalPrice()
        {
            // Arrange
            ICheckout checkout = new Checkout();
            checkout.AddItem(new CheckoutItem("A", 50));
            checkout.AddItem(new CheckoutItem("B", 30));

            // Act
            var total = checkout.CalculateTotal();

            // Assert
            Assert.AreEqual(80, total);
        }

        /// <summary>
        /// Test that the checkout can sum the prices of the items, even if the checkout is empty
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        public void TestCalculateTotalPrice_Empty()
        {
            // Arrange
            ICheckout checkout = new Checkout();

            // Act
            var total = checkout.CalculateTotal();

            // Assert
            Assert.AreEqual(0, total);
        }

        #endregion

        #region TestSpecialOffersCanBeAdded

        /// <summary>
        /// Test that special offers can be added to the checkout
        /// </summary>
        /// <remarks>GREEN</remarks>
        [TestMethod]
        public void TestSpecialOffersCanBeAdded()
        {
            // Arrange
            ICheckout checkout = new Checkout();
            checkout.AddItem(new CheckoutItem("B", 30));
            checkout.AddItem(new CheckoutItem("A", 50));
            checkout.AddItem(new CheckoutItem("B", 30));

            // Act
            checkout.AddSpecialOffer(new MultiBuySpecialOffer(2, "B", 45));

            // Assert
            Assert.AreEqual(1, checkout.SpecialOffers.Count);
        }

        /// <summary>
        /// Test that special offers can be added to the checkout
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSpecialOffersCanBeAdded_Null()
        {
            // Arrange
            ICheckout checkout = new Checkout();

            // Act
            checkout.AddSpecialOffer(null);

            // Assert
            Assert.Fail("ArgumentNullException was not thrown.");
        }


        /// <summary>
        /// Test that special offers can be added to the checkout
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        public void TestSpecialOffersCanBeAdded_NoSpecialOffers()
        {
            // Arrange
            ICheckout checkout = new Checkout();
            checkout.AddItem(new CheckoutItem("B", 30));
            checkout.AddItem(new CheckoutItem("A", 50));
            checkout.AddItem(new CheckoutItem("B", 30));

            // Act

            // Assert
            Assert.AreEqual(0, checkout.SpecialOffers.Count);
        }

        #endregion

        #region TestSpecialOffersAreApplied

        /// <summary>
        /// Test that special offers are properly applied, and the total is affected accordingly.
        /// </summary>
        /// <remarks>GREEN</remarks>
        [TestMethod]
        public void TestSpecialOffersAreApplied()
        {
            // Arrange
            ICheckout checkout = new Checkout();
            checkout.AddItem(new CheckoutItem("B", 30));
            checkout.AddItem(new CheckoutItem("A", 50));
            checkout.AddItem(new CheckoutItem("B", 30));

            // Act
            checkout.AddSpecialOffer(new MultiBuySpecialOffer(2, "B", 45));

            // Assert
            Assert.AreEqual(95, checkout.CalculateTotal());
        }

        /// <summary>
        /// Test that special offers are properly applied, and the total is affected accordingly.
        /// </summary>
        /// <remarks>RED</remarks>
        [TestMethod]
        public void TestSpecialOffersAreApplied_WithAdditionalItemsNotCoveredByOffer()
        {
            // Arrange
            ICheckout checkout = new Checkout();
            checkout.AddItem(new CheckoutItem("B", 30));
            checkout.AddItem(new CheckoutItem("A", 50));
            checkout.AddItem(new CheckoutItem("B", 30));
            checkout.AddItem(new CheckoutItem("B", 30));

            // Act
            checkout.AddSpecialOffer(new MultiBuySpecialOffer(2, "B", 45));

            // Assert
            Assert.AreEqual(125, checkout.CalculateTotal());
        }

        #endregion
    }
}
