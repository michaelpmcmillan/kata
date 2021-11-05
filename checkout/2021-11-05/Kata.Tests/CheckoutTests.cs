using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private readonly AutoMocker _mocker = new();

        [Fact]
        public void GivenNothingHasBeenScanned_WhenGetTotalPrice_ShouldReturnZero()
        {
            var subject = _mocker.CreateInstance<Checkout>();

            var totalPrice = subject.GetTotalPrice();

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
        public void GivenItemsAreScanned_WhenGetTotalPrice_ShouldReturnTotalItemPrice(string items, int itemPrice)
        {
            var subject = _mocker.CreateInstance<Checkout>();
            foreach(var item in items.Split(" "))
            {
                subject.Scan(item);
            }

            var totalPrice = subject.GetTotalPrice();

            totalPrice.Should().Be(itemPrice);
        }
    }
}
