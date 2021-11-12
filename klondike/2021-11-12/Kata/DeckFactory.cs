namespace Kata
{
    public class DeckFactory
    {
        public CardDeck Create() =>
            new CardDeck(GetAllCards());

        private IEnumerable<Card> GetAllCards() => 
            Enum.GetValues<CardValue>()
                .SelectMany(cardValue => Enum.GetValues<CardType>()
                .Select(cardType => GetCard(cardValue, cardType)));

        private Card GetCard(CardValue cardValue, CardType cardType) =>
            new Card(cardValue, cardType, false);
    }
}