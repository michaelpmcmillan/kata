using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using VendingMachineKata.Coin;
using VendingMachineKata.ConsoleApp.Parse;
using Xunit;

namespace VendingMachineKata.Console.Tests.Parse
{
    public class ParseConsoleInputTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public ParseConsoleInputTests()
        {
            Fixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenParse_WithNickel_ThenEnumNickleIsReturned()
        {
            IParseConsoleInput parseConsoleInput = Mocker.CreateInstance<ParseConsoleInput>();

            var coinValue = parseConsoleInput.Parse("Nickle");

            coinValue.Should().Be(CoinEnum.Nickle);
        }

        [Fact]
        public void WhenParse_WithDime_ThenEnumDimeIsReturned()
        {
            IParseConsoleInput parseConsoleInput = Mocker.CreateInstance<ParseConsoleInput>();

            var coinValue = parseConsoleInput.Parse("Dime");

            coinValue.Should().Be(CoinEnum.Dime);
        }

        [Fact]
        public void WhenParse_WithQuarter_ThenEnumQuarterIsReturned()
        {
            IParseConsoleInput parseConsoleInput = Mocker.CreateInstance<ParseConsoleInput>();

            var coinValue = parseConsoleInput.Parse("Quarter");

            coinValue.Should().Be(CoinEnum.Quarter);
        }

        [Fact]
        public void WhenParse_WithPenny_ThenEnumPennyIsReturned()
        {
            IParseConsoleInput parseConsoleInput = Mocker.CreateInstance<ParseConsoleInput>();

            var coinValue = parseConsoleInput.Parse("Penny");

            coinValue.Should().Be(CoinEnum.Penny);
        }

        [Fact]
        public void WhenParse_WithAnyUnknownCoin_ThenEnumInvalidCoinIsReturned()
        {
            IParseConsoleInput parseConsoleInput = Mocker.CreateInstance<ParseConsoleInput>();
            var randomCoinName = Fixture.Create<string>();

            var coinValue = parseConsoleInput.Parse(randomCoinName);

            coinValue.Should().Be(CoinEnum.InvalidCoin);
        }
    }
}
