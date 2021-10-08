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
        [Fact]
        public void When()
        {
            // Given

            // When
            var totalPrice = _subject.GetTotalPrice();

            // Then
            totalPrice.Should().Be(0);
        }
    }
}
