using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace FizzBuzz.Tests;

public class FizzBuzzResultGeneratorTests
{
    private readonly AutoMocker _mocker = new();

    [Fact]
    public void WhenGenerate_ReturnItemsInOrder()
    {
        var subject = _mocker.CreateInstance<FizzBuzzResultGenerator>();
        for (var i = 1; i <= 100; i++)
        {
            _mocker
                .GetMock<IFizzBuzzItemGenerator>()
                .Setup(mock => mock.GetItem(i))
                .Returns(i.ToString());
        }

        var items = subject.Generate(1, 100);

        items.Should().BeEquivalentTo(Enumerable.Range(1, 100).Select(number => number.ToString()),
            options => options.WithStrictOrdering());
    }
}