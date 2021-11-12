using Xunit;
using FluentAssertions;

namespace Kata.Tests;

public class GameTests
{
    private readonly Game _subject;

    public GameTests()
    {
        var deckFactory = new DeckFactory();
        var deckShuffler = new DeckShuffler();
        var gameFactory = new GameFactory(deckFactory, deckShuffler);
        _subject = gameFactory.Create();
    }

    [Fact]
    public void WhenMoveCardFromStockToDiscard_ThenCardShouldHaveMoved()
    {
        // Given
        var topStockCard = _subject.CardTable.Stock.Peek();

        // When
        _subject.MoveCardFromStockToDiscard();

        // Then
        _subject.CardTable.Stock.Peek().Should().NotBe(topStockCard);
        _subject.CardTable.Discard.Peek().Should().Be(topStockCard with { IsFaceUp = true });
    }
}