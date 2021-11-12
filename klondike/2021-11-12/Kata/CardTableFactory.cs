namespace Kata
{
    public class CardTableFactory
    {
        private readonly DeckFactory _deckFactory;
        private readonly DeckShuffler _deckShuffler;

        public CardTableFactory(DeckFactory deckFactory, DeckShuffler deckShuffler)
        {
            _deckFactory = deckFactory;
            _deckShuffler = deckShuffler;
        }

        public CardTable Create() =>
            new CardTable(_deckShuffler.Shuffle(_deckFactory.Create()));
    }
}
