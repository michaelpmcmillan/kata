using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata.test
{
    /// <summary>
    /// A set of tests for the CheckoutItem class.
    /// </summary>
    [TestClass]
    public class TestCheckoutItem
    {
        #region TestItemCanBeIdentifiedBySKU

        /// <summary>
        /// Test that an item can be identified by it's SKU letter
        /// </summary>
        [TestMethod]
        public void TestItemCanBeIdentifiedBySKU()
        {
            // Arrange
            ICheckoutItem item;

            // Act
            item = new CheckoutItem("A", 50);

            // Assert
            Assert.AreEqual("A", item.SKU);
        }

        #endregion
    }
}
