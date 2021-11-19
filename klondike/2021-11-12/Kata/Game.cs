namespace Kata;
public class Game
{
    public CardTable CardTable { get; }

    public Game(CardTable cardTable)
    {
        CardTable = cardTable;
    }

    public void MoveCardFromStockToDiscard()
    {
        if (CardTable.Stock.Count == 0)
        {
            CardTable.Discard.MoveAllCardsTo(CardTable.Stock, faceUp: false);
        }
        else
        {
            CardTable.Stock.MoveCardTo(CardTable.Discard, faceUp: true);
        }
    }
}
