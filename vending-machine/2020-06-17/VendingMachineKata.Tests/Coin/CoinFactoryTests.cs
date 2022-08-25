using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using VendingMachineKata.Coin;
using Xunit;

namespace VendingMachineKata.Tests.Coin
{
    public class CoinFactoryTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public CoinFactoryTests()
        {
            Fixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenCreate_WithCoinEnumNickel_ThenNickleIsCreated()
        {
            const CoinEnum value = CoinEnum.Nickle;
            var coinFactory = Mocker.CreateInstance<CoinFactory>();

            var coin = coinFactory.Create(value);

            coin.Should().BeOfType<Nickle>();
            coin.Value.Should().Be(5);
        }

        [Fact]
        public void WhenCreate_WithCoinEnumDime_ThenDimeIsCreated()
        {
            const CoinEnum value = CoinEnum.Dime;
            var coinFactory = Mocker.CreateInstance<CoinFactory>();

            var coin = coinFactory.Create(value);

            coin.Should().BeOfType<Dime>();
            coin.Value.Should().Be(10);
        }

        [Fact]
        public void WhenCreate_WithCoinEnumQuarter_ThenQuarterIsCreated()
        {
            const CoinEnum value = CoinEnum.Quarter;
            var coinFactory = Mocker.CreateInstance<CoinFactory>();

            var coin = coinFactory.Create(value);

            coin.Should().BeOfType<Quarter>();
            coin.Value.Should().Be(25);
        }

        [Fact]
        public void WhenCreate_WithCoinEnumInvalid_ThenInvalidCoinIsCreated()
        {
            const CoinEnum value = CoinEnum.InvalidCoin;
            var coinFactory = Mocker.CreateInstance<CoinFactory>();

            var coin = coinFactory.Create(value);

            coin.Should().BeOfType<InvalidCoin>();
            coin.Value.Should().Be(0);
        }
    }
}
