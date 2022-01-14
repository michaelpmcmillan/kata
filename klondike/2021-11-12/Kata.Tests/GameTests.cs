using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

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
    public void WhenMoveCardFromStockToDiscard_ThenCardShouldHaveMoved_AndBeFaceUp()
    {
        // Given
        var topStockCard = _subject.CardTable.Stock.Peek();

        // When
        _subject.MoveCardFromStockToDiscard();

        // Then
        _subject.CardTable.Stock.Peek().Should().NotBe(topStockCard);
        _subject.CardTable.Discard.Peek().Should().Be(topStockCard with { IsFaceUp = true });
    }

    [Fact]
    public void GivenThereIs1CardInStock_WhenMoveCardFromStockToDiscard_ThenDiscardIsTurnedOverToBeNewStock()
    {
        // Given
        var topCard = _subject.CardTable.Stock.Peek();
        var originalStock = new Stack<Card>(
            _subject.CardTable.Stock.ToList().Reverse<Card>());
        while (_subject.CardTable.Stock.Count > 0)
        {
            _subject.MoveCardFromStockToDiscard();
        }

        // When
        _subject.MoveCardFromStockToDiscard();

        // Then
        _subject.CardTable.Discard.Count.Should().Be(0);
        _subject.CardTable.Stock.Count.Should().Be(52);
        _subject.CardTable.Stock.Should().BeEquivalentTo(originalStock, options => options.WithStrictOrdering());
        _subject.CardTable.Stock.Peek().Should().Be(topCard);
    }

    // Move a card from the tableau or discard pile to one of the foundation piles.
    // If the foundation pile is empty, only an Ace can be placed there, otherwise
    //   only the next highest card in the appropriate suit can be placed
    //   (so if a foundation pile is currently showing a four of hearts,
    //     only the five of hearts may be placed there).
}