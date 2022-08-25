using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata.test
{
    /// <summary>
    /// A set of tests for the CheckOutItemCollection class.
    /// </summary>
    [TestClass]
    public class TestCheckOutItemCollection
    {
        #region TestItemCanBeIdentifiedBySKU

        /// <summary>
        /// Test that an item can be identified by it's SKU letter
        /// </summary>
        /// <remarks>In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. 
        /// In our store, we’ll use individual letters of the alphabet(A, B, C, and so on).</remarks>
        [TestMethod]
        public void TestItemCanBeIdentifiedBySKU()
        {
            // Arrange
            var collection = new CheckOutItemCollection();
            var a = new CheckoutItem("A", 50);
            var b = new CheckoutItem("B", 30);
            var c = new CheckoutItem("C", 20);
            var d = new CheckoutItem("D", 15);

            // Act
            collection.Add(a);
            collection.Add(b);
            collection.Add(c);
            collection.Add(d);

            // Assert
            Assert.AreEqual("A", collection["A"].SKU);
            Assert.AreEqual("B", collection["B"].SKU);
            Assert.AreEqual("C", collection["C"].SKU);
            Assert.AreEqual("D", collection["D"].SKU);
        }

        #endregion
    }
}
