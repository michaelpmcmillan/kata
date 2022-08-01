using FluentAssertions;

namespace FizzBuzz.Tests;

public class FizzBuzzResultGeneratorTests
{
    [Fact]
    public void WhenGenerate_Return1to100()
    {
        var subject = new FizzBuzzResultGenerator();

        var items = subject.Generate();

        items.Should().BeEquivalentTo(
            Enumerable.Range(1, 100).Select(number => number.ToString()),
            options => options.WithStrictOrdering());
    }
}