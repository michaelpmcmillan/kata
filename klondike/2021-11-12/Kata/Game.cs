namespace Kata;
public class Game
{
    public CardTable CardTable { get; }

    public Game(CardTable cardTable)
    {
        CardTable = cardTable;
    }

    public void MoveCardFromStockToDiscard() =>
        CardTable.Discard.Push(
            CardTable.Stock.Pop() with { IsFaceUp = true });
}
