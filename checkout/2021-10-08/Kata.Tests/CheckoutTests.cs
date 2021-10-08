using System;
using Moq.AutoMock;
using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private readonly AutoMocker _mocker = new();
        private readonly ICheckout _subject;

        public CheckoutTests()
        {
            _subject = _mocker.CreateInstance<Checkout>();
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        [InlineData("Z", 0)]
        public void When(string sku, float expectedPrice)
        {
            // Given
            _subject.Scan(sku[0]);

            // When
            var totalPrice = _subject.GetTotalPrice();

            // Then
            totalPrice.Should().Be(expectedPrice);
        }
    }
}
