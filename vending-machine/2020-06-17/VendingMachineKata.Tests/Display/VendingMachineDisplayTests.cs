using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using VendingMachineKata.Coin;
using VendingMachineKata.CoinRegister;
using VendingMachineKata.Display;
using Xunit;

namespace VendingMachineKata.Tests.Display
{
    public class VendingMachineDisplayTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public VendingMachineDisplayTests()
        {
            Fixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void GivenNoCoinsHaveBeenInserted_WhenUpdate_ThenInsertCoinShouldBeDisplayed()
        {
            IVendingMachineDisplay vendingMachineDisplay = Mocker.CreateInstance<VendingMachineDisplay>();
            ICoinCollection coinCollection = new CoinCollection();
            var expectedString = Resources.Strings.InsertCoin;

            vendingMachineDisplay.Update(coinCollection);

            vendingMachineDisplay.Display.Should().Be(expectedString);
            Mocker.Verify<IDisplayWriter>(d => d.Write(expectedString), Times.Once);
        }

        [Fact]
        public void GivenANickelHasBeenInserted_WhenUpdate_Then5CentsShouldBeDisplayed()
        {
            IVendingMachineDisplay vendingMachineDisplay = Mocker.CreateInstance<VendingMachineDisplay>();
            ICoinCollection coinCollection = new CoinCollection() { new Nickle() };
            var expectedString = string.Format(Resources.Strings.DisplayCoinTotal, 0.05);

            vendingMachineDisplay.Update(coinCollection);

            vendingMachineDisplay.Display.Should().Be(expectedString);
            Mocker.Verify<IDisplayWriter>(d => d.Write(expectedString), Times.Once);
        }
    }
}
