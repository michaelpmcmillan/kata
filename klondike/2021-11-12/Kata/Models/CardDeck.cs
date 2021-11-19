namespace Kata
{
    public class CardDeck : Stack<Card>
    {
        public CardDeck() : base() { }
        public CardDeck(IEnumerable<Card> collection) : base(collection) { }

        public void MoveCardTo(CardDeck other, bool faceUp) =>
            other.Push(
                this.Pop() with { IsFaceUp = faceUp });

        public void MoveAllCardsTo(CardDeck other, bool faceUp)
        {
            while (Count != 0)
            {
                this.MoveCardTo(other, faceUp);
            }
        }
    }
}
