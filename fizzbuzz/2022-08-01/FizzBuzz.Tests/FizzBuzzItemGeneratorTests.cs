using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Tests
{
    public class FizzBuzzItemGeneratorTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "5")]
        [InlineData(6, "Fizz")]
        [InlineData(7, "7")]
        [InlineData(8, "8")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "10")]
        public void GivenAllFizzNumbersBetween1and100_WhenGetItem_ReturnFizzForEachItem(int number, string expectation)
        {
            var subject = new FizzBuzzItemGenerator();

            var item = subject.GetItem(number);

            item.Should().Be(expectation);
        }
    }
}
