namespace Kata
{
    public class CardTable
    {
        public CardTable(CardDeck cardDeck)
        {
            Stock = cardDeck;
        }

        public CardDeck Stock { get; }
        public CardDeck Discard { get; } = new();
    }
}