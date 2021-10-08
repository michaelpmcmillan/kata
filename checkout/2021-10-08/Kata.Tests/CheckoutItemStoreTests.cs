using Moq.AutoMock;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace Kata.Tests
{
    public class CheckoutItemStoreTests
    {
        private readonly AutoMocker _mocker = new();
        private readonly ICheckoutItemStore _subject;

        public CheckoutItemStoreTests()
        {
            _subject = _mocker.CreateInstance<CheckoutItemStore>();
        }

        [Fact]
        public void GivenSKUsHaveBeenScanned_WhenGetScannedItems_ThenReturnScannedItems()
        {
            // Given
            _subject.Scan('A');
            _subject.Scan('A');
            _subject.Scan('B');
            _subject.Scan('C');
            _subject.Scan('D');

            // When
            var items = _subject.GetScannedItems();

            // Then
            items.Should().BeEquivalentTo(new Dictionary<char, int>()
                {
                    { 'A', 2 },
                    { 'B', 1 },
                    { 'C', 1 },
                    { 'D', 1 },
                });
        }
    }
}
