using Moq.AutoMock;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using AutoFixture;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private readonly AutoMocker _mocker = new();
        private readonly Fixture _autoFixture = new();
        private readonly ICheckout _subject;

        public CheckoutTests()
        {
            _subject = _mocker.CreateInstance<Checkout>();
        }

        [Fact]
        public void GivenSKUHasBeenScanned_WhenGetTotalPrice_ThenReturnExpectedPrice()
        {
            // Given
            var scannedItems = new Dictionary<char, int>()
                {
                    { _autoFixture.Create<char>(), _autoFixture.Create<int>() }
                };
            var calculatedItemPrice = _autoFixture.Create<int>();

            _mocker.GetMock<ICheckoutItemStore>()
                .Setup(itemStore => itemStore.GetScannedItems())
                .Returns(scannedItems);

            _mocker.GetMock<ICheckoutItemCalculator>()
                .Setup(itemCalculator => itemCalculator.GetTotalPrice(scannedItems))
                .Returns(calculatedItemPrice);

            // When
            var totalPrice = _subject.GetTotalPrice();

            // Then
            totalPrice.Should().Be(calculatedItemPrice);
        }
    }
}
