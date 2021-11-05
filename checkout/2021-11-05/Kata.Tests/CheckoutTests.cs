using System;
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
        public void GivenItemIsScanned_WhenGetTotalPrice_ShouldReturnItemPrice(string item, int itemPrice)
        {
            var subject = _mocker.CreateInstance<Checkout>();
            subject.Scan(item);

            var totalPrice = subject.GetTotalPrice();

            totalPrice.Should().Be(itemPrice);
        }
    }
}
