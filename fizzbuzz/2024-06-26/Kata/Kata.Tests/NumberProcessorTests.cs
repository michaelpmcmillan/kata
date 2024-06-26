using FluentAssertions;
using Moq.AutoMock;

namespace Kata.Tests;

public class NumberProcessorTests
{
    private AutoMocker _mocker = new();

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    public void WhenGet(int number, string expectedResult)
    {
        // Given
        var subject = _mocker.CreateInstance<NumberProcessor>();

        // When
        var result = subject.Get(number);

        // Then
        result.Should().Be(expectedResult);
    }
}