namespace Kata
{
    public class CardDeck : Stack<Card>
    {
        public CardDeck() : base() { }
        public CardDeck(IEnumerable<Card> collection) : base(collection) { }
    }
}
