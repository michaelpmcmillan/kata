using Xunit;
using Kata;
using FluentAssertions;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void GivenAnEmptyBasket_WhenGetTotalPrice_ReturnZero()
        {
            var checkoutCalculator = new CheckoutCalculator();
            var checkout = new Checkout(checkoutCalculator);

            var result = checkout.GetTotalPrice();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        [InlineData("A,A", 100)]
        [InlineData("A,B,C,D", 115)]
        public void GivenAnItemIsScanned_WhenGetTotalPrice_ReturnCost(string items, int cost)
        {
            var checkoutCalculator = new CheckoutCalculator();
            var checkout = new Checkout(checkoutCalculator);

            foreach(var item in items.Split(','))
            {
                checkout.Scan(item);
            }

            var result = checkout.GetTotalPrice();

            result.Should().Be(cost);
        }
    }
}
