using Moq.AutoMock;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

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
        public void GivenSKUHasBeenScanned_WhenGetTotalPrice_ThenReturnExpectedPrice(string sku, float expectedPrice)
        {
            // Given
            _mocker.GetMock<ICheckoutItemStore>()
                .Setup(itemStore => itemStore.GetScannedItems())
                .Returns(new Dictionary<char, int>()
                    {
                        { sku[0], 1 }
                    });

            // When
            var totalPrice = _subject.GetTotalPrice();

            // Then
            totalPrice.Should().Be(expectedPrice);
        }
    }
}
