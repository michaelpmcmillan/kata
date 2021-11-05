using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void GivenNothingHasBeenScanned_WhenGetTotalPrice_ShouldReturnZero()
        {
            var checkoutCalculator = new CheckoutCalculator();
            var checkout = new Checkout(checkoutCalculator);

            var totalPrice = checkout.GetTotalPrice();

            totalPrice.Should().Be(0);
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        [InlineData("A B C D", 115)]
        [InlineData("A A B C C D D", 200)]
        [InlineData("A A A", 130)]
        [InlineData("A A A A", 180)]
        [InlineData("B B", 45)]
        [InlineData("B B B", 75)]
        [InlineData("A A A A B B B", 255)]
        public void GivenItemsAreScanned_WhenGetTotalPrice_ShouldReturnTotalItemPrice(string items, int itemPrice)
        {
            var checkoutCalculator = new CheckoutCalculator();
            var checkout = new Checkout(checkoutCalculator);
            foreach(var item in items.Split(" "))
            {
                checkout.Scan(item);
            }

            var totalPrice = checkout.GetTotalPrice();

            totalPrice.Should().Be(itemPrice);
        }
    }
}
