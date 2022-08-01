using FluentAssertions;

namespace FizzBuzz.Tests
{
    public class FizzBuzzItemGeneratorTests
    {
        public static IEnumerable<object[]> NumbersDivisibleBy3 = Enumerable.Range(1, 200)
            .Where(number => number % 3 == 0)
            .Where(number => number % 5 != 0)
            .Select(number => new object[] { number });

        public static IEnumerable<object[]> NumbersDivisibleBy5 = Enumerable.Range(1, 200)
            .Where(number => number % 5 == 0)
            .Where(number => number % 3 != 0)
            .Select(number => new object[] { number });

        public static IEnumerable<object[]> NumbersDivisibleBy3And5 = Enumerable.Range(1, 200)
            .Where(number => number % 3 == 0)
            .Where(number => number % 5 == 0)
            .Select(number => new object[] { number });

        public static IEnumerable<object[]> NumbersNotDivisibleBy3Or5 = Enumerable.Range(1, 200)
            .Where(number => number % 3 != 0)
            .Where(number => number % 5 != 0)
            .Select(number => new object[] { number });

        [Theory]
        [MemberData(nameof(NumbersDivisibleBy3))]
        public void GivenNumbersDivisibleBy3_WhenGetItem_ThenReturnFizz(int number)
        {
            var subject = new FizzBuzzItemGenerator();

            var item = subject.GetItem(number);

            item.Should().Be("Fizz");
        }

        [Theory]
        [MemberData(nameof(NumbersDivisibleBy5))]
        public void GivenNumbersDivisibleBy5_WhenGetItem_ThenReturnBuzz(int number)
        {
            var subject = new FizzBuzzItemGenerator();

            var item = subject.GetItem(number);

            item.Should().Be("Buzz");
        }

        [Theory]
        [MemberData(nameof(NumbersDivisibleBy3And5))]
        public void GivenNumbersDivisibleBy3And5_WhenGetItem_ThenReturnFizzBuzz(int number)
        {
            var subject = new FizzBuzzItemGenerator();

            var item = subject.GetItem(number);

            item.Should().Be("FizzBuzz");
        }

        [Theory]
        [MemberData(nameof(NumbersNotDivisibleBy3Or5))]
        public void GivenNumbersNotDivisibleBy3Or5_WhenGetItem_ThenReturnFizzBuzz(int number)
        {
            var subject = new FizzBuzzItemGenerator();

            var item = subject.GetItem(number);

            item.Should().Be(number.ToString());
        }
    }
}
