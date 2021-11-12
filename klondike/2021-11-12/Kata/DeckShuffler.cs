namespace Kata
{
    public class DeckShuffler
    {
        private readonly Random random = new();

        public CardDeck Shuffle(CardDeck cardDeck) =>
            new CardDeck(cardDeck.OrderBy(c => Next()).AsEnumerable());

        private int Next() => random.Next(1, 520);
    }
}
