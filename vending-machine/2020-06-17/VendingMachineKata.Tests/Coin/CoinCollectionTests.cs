using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using VendingMachineKata.Coin;
using VendingMachineKata.CoinRegister;
using Xunit;

namespace VendingMachineKata.Tests.Coin
{
    public class CoinCollectionTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public CoinCollectionTests()
        {
            Fixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenAddCoin_CoinShouldBeAdded()
        {
            ICoinCollection coinCollection = Mocker.CreateInstance<CoinCollection>();
            ICoin coin = new Nickle();

            coinCollection.AddCoin(coin);

            coinCollection.Should().BeEquivalentTo(new [] { coin });
        }
    }
}
