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

        [Fact]
        public void GivenItemAIsScanned_WhenGetTotalPrice_ShouldReturn50()
        {
            var subject = _mocker.CreateInstance<Checkout>();
            subject.Scan("A");

            var totalPrice = subject.GetTotalPrice();

            totalPrice.Should().Be(50);
        }
    }
}
