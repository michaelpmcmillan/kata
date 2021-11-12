using Xunit;
using FluentAssertions;

namespace Kata.Tests;

public class GameFactoryTests
{
    [Fact]
    public void WhenGameIsCreated_ThenThereShouldBe52CardsInTheStockPile()
    {
        // Given
        var deckFactory = new DeckFactory();
        var deckShuffler = new DeckShuffler();
        var gameFactory = new GameFactory(deckFactory, deckShuffler);

        // When
        var game = gameFactory.Create();

        // Then
        game.CardTable.Stock.Count.Should().Be(52);
    }

    [Fact]
    public void WhenGameIsCreated_ThenThereShouldBe0CardsInTheDiscardPile()
    {
        // Given
        var deckFactory = new DeckFactory();
        var deckShuffler = new DeckShuffler();
        var gameFactory = new GameFactory(deckFactory, deckShuffler);

        // When
        var game = gameFactory.Create();

        // Then
        game.CardTable.Discard.Count.Should().Be(0);
    }

    [Fact]
    public void WhenGameIsCreated_TheStockDeckShouldAlwaysContainTheSameCards()
    {
        // Given
        var deckFactory = new DeckFactory();
        var deckShuffler = new DeckShuffler();
        var gameFactory = new GameFactory(deckFactory, deckShuffler);

        // When
        var game1 = gameFactory.Create();
        var game2 = gameFactory.Create();

        // Then
        game1.CardTable.Stock.Should().BeEquivalentTo(game2.CardTable.Stock);
    }

    [Fact]
    public void WhenGameIsCreated_TheStockDeckShouldBeShuffled()
    {
        // Given
        var deckFactory = new DeckFactory();
        var deckShuffler = new DeckShuffler();
        var gameFactory = new GameFactory(deckFactory, deckShuffler);

        // When
        var game1 = gameFactory.Create();
        var game2 = gameFactory.Create();

        // Then
        game1.CardTable.Stock.Should().NotBeSameAs(game2.CardTable.Stock);
    }
}