using FluentAssertions;
using Moq.AutoMock;

namespace Kata.Tests;

public class FizzbuzzOrchestratorTests
{
    private AutoMocker _mocker = new();

    [Fact]
    public void WhenPrint_ThenReturnItems()
    {
        // Given
        var subject = _mocker.CreateInstance<FizzbuzzOrchestrator>();

        _mocker.GetMock<INumberProcessor>()
            .Setup(processor => processor.Get(1))
            .Returns("1");

        _mocker.GetMock<INumberProcessor>()
            .Setup(processor => processor.Get(2))
            .Returns("2");

        // When
        var items = subject.Execute(1, 2);

        // Then
        items.Should().BeEquivalentTo(["1", "2"]);
    }
}
