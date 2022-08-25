using System;
using System.Reflection.PortableExecutable;
using AutoFixture;
using CheckoutKata.Item;
using CheckoutKata.Lookup;
using CheckoutKata.Scanning;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public CheckoutTests()
        {
            Fixture = new Fixture();
            Mocker = new AutoMocker();
        }


        [Theory]
        [InlineData('A', 50)]
        [InlineData('B', 30)]
        [InlineData('C', 20)]
        [InlineData('D', 15)]
        public void WhenScanSingleItem_ThenItemShouldBeInstantiated(char itemCode, decimal itemPrice)
        {
            ICheckout checkout = Mocker.CreateInstance<Checkout>();
            ICheckoutItem expectedCheckoutItem = new CheckoutItem(itemCode, itemPrice);

            Mocker.GetMock<IItemLookup>()
                .Setup(scanner => scanner.Lookup(itemCode))
                .Returns(expectedCheckoutItem);

            var item = checkout.AppendItem(itemCode);

            item.ItemCode.Should().Be(itemCode);
            item.ItemPrice.Should().Be(itemPrice);
        }

        [Fact]
        public void GivenTwoItemsHaveBeenScanned_WhenGetTotalPrice_ThenTheSumOfItemPriceIsReturned()
        {
            ICheckout checkout = Mocker.CreateInstance<Checkout>();

            Mocker.GetMock<IItemLookup>().Setup(scanner => scanner.Lookup('A')).Returns(new CheckoutItem('A', 50));
            Mocker.GetMock<IItemLookup>().Setup(scanner => scanner.Lookup('B')).Returns(new CheckoutItem('B', 30));

            checkout.AppendItem('A');
            checkout.AppendItem('B');

            var totalPrice = checkout.GetTotalPrice();

            totalPrice.Should().Be(80);
        }

        [Fact]
        public void WhenAnInvalidItemCodeIsScanned_ThenItIsNotAddedToTheCheckout()
        {
            ICheckout checkout = Mocker.CreateInstance<Checkout>();

            Mocker.GetMock<IItemLookup>().Setup(scanner => scanner.Lookup('E')).Returns((CheckoutItem)null);

            checkout.AppendItem('E');

            var totalPrice = checkout.GetTotalPrice();

            totalPrice.Should().Be(0);
        }
    }
}
