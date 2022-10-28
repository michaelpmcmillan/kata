using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using Xunit.Abstractions;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private readonly AutoMocker _mocker = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public void GivenNothingScanned_WhenGetTotal_ThenReturnZero()
        {
            ICheckout subject = _mocker.CreateInstance<Checkout>();

            var result = subject.GetTotal();

            result.Should().Be(0);
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        public void GivenSingleItemScanned_WhenGetTotal_ThenReturnExpectedTotal(string sku, int expectedTotal)
        {
            var subject = _mocker.CreateInstance<Checkout>();
            var items = new Dictionary<string, int>();

            items.Add(sku, 1);

            _mocker.GetMock<ICalculator>().Setup(a => a.GetPrice(items)).Returns(expectedTotal);

            subject.Scan(sku);

            var result = subject.GetTotal();

            result.Should().Be(expectedTotal);
        }


        [Theory]
        [InlineData("AAA", 130)]
        [InlineData("BB", 45)]
        public void GivenMultipleItemsScanned_WhenGetTotal_ThenReturnExpectedPrice(string sku, int expectedTotal)
        {
            var subject = _mocker.CreateInstance<Checkout>();

            var items = new Dictionary<string, int>();

            items.Add(sku[0].ToString(), sku.Length);

            _mocker.GetMock<ICalculator>().Setup(a => a.GetPrice(items)).Returns(expectedTotal);

            foreach (var item in sku.ToCharArray())
            {
                subject.Scan(item.ToString());
            }

            var result = subject.GetTotal();

            result.Should().Be(expectedTotal);
        }
    }
}