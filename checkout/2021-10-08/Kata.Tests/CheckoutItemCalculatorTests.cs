using Moq.AutoMock;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace Kata.Tests
{
    public class CheckoutItemCalculatorTests
    {
        private readonly AutoMocker _mocker = new();
        private readonly ICheckoutItemCalculator _subject;

        public CheckoutItemCalculatorTests()
        {
            _subject = _mocker.CreateInstance<CheckoutItemCalculator>();
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        [InlineData("Z", 0)]
        public void GivenSKUHasBeenScanned_WhenGetTotalPrice_ThenReturnExpectedPrice(string sku, float expectedPrice)
        {
            // Given
            var scannedItems = new Dictionary<char, int>()
            {
                { sku[0], 1 }
            };

            // When
            var totalPrice = _subject.GetTotalPrice(scannedItems);

            // Then
            totalPrice.Should().Be(expectedPrice);
        }
    }
}
