using FluentAssertions;
using Moq.AutoMock;

namespace Kata.Tests
{
    public class ItemResposityTests
    {
        private readonly AutoMocker _mocker = new();

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void GivenSingleItemScanned_WhenGetTotal_ThenReturnExpectedTotal(string sku, int expectedTotal)
        {
            var subject = _mocker.CreateInstance<ItemRepository>();

            var result = subject.GetItem(sku);

            result.FullPrice.Should().Be(expectedTotal);
        }
    }
}
