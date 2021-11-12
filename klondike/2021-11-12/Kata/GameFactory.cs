using System;
namespace Kata
{
    public class GameFactory
    {
        private DeckFactory _deckFactory;
        private DeckShuffler _deckShuffler;

        public GameFactory(DeckFactory deckFactory, DeckShuffler deckShuffler)
        {
            _deckFactory = deckFactory;
            _deckShuffler = deckShuffler;
        }

        public Game Create() =>
            new Game(new CardTable(GetShuffledDeck()));

        private CardDeck GetShuffledDeck() =>
            _deckShuffler.Shuffle(_deckFactory.Create());
    }
}
