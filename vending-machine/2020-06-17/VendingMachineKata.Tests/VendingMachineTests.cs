using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using VendingMachineKata.Coin;
using VendingMachineKata.CoinRegister;
using Xunit;

namespace VendingMachineKata.Tests
{
    public class VendingMachineTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public VendingMachineTests()
        {
            Fixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Theory]
        [InlineData(CoinEnum.Penny)]
        [InlineData(CoinEnum.Nickle)]
        [InlineData(CoinEnum.Dime)]
        [InlineData(CoinEnum.Quarter)]
        [InlineData(CoinEnum.InvalidCoin)]
        public void WhenInsertCoin_WithAnyCoin_ICoinFactoryCreateShouldBeInvoked(CoinEnum coin)
        {
            IVendingMachine vendingMachine = Mocker.CreateInstance<VendingMachine>();

            vendingMachine.InsertCoin(coin);

            Mocker.Verify<ICoinFactory>(c => c.Create(coin), Times.Once);
        }

        [Theory]
        [InlineData(CoinEnum.Nickle, typeof(Nickle))]
        [InlineData(CoinEnum.Dime, typeof(Dime))]
        [InlineData(CoinEnum.Quarter, typeof(Quarter))]
        public void WhenInsertCoin_WithAValidCoin_ICoinCollectionAddCoinShouldBeInvoked(CoinEnum coinEnum, Type coinType)
        {
            IVendingMachine vendingMachine = Mocker.CreateInstance<VendingMachine>();
            ICoin coin = (ICoin)Activator.CreateInstance(coinType);

            Mocker.GetMock<ICoinFactory>().Setup(c => c.Create(coinEnum)).Returns(coin);

            vendingMachine.InsertCoin(coinEnum);

            Mocker.Verify<ICoinSlot>(c => c.AddCoin(coin), Times.Once);
        }

        [Theory]
        [InlineData(CoinEnum.Penny, typeof(InvalidCoin))]
        [InlineData(CoinEnum.InvalidCoin, typeof(InvalidCoin))]
        public void WhenInsertCoin_WithAnInvalidCoin_ICoinCollectionAddCoinShouldBeInvoked(CoinEnum coinEnum, Type coinType)
        {
            IVendingMachine vendingMachine = Mocker.CreateInstance<VendingMachine>();
            ICoin coin = (ICoin)Activator.CreateInstance(coinType);

            Mocker.GetMock<ICoinFactory>().Setup(c => c.Create(coinEnum)).Returns(coin);

            vendingMachine.InsertCoin(coinEnum);

            Mocker.Verify<ICoinReturn>(c => c.AddCoin(coin), Times.Once);
        }

        [Fact]
        public void WhenGetCoinTotal_ThenICoinCollectionGetCoinTotalShouldBeInvoked()
        {
            IVendingMachine vendingMachine = Mocker.CreateInstance<VendingMachine>();

            vendingMachine.GetCoinTotal();

            Mocker.Verify<ICoinSlot, double>(c => c.GetCoinTotal(), Times.Once);
        }
    }
}
