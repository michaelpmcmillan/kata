namespace Kata
{
    public class ItemRepository : IItemRespository
    {
        private Dictionary<string, Item> _itemRepository = new Dictionary<string, Item>
        {
            { "A", new Item("A", 50, 3, 130) },
            { "B", new Item("B", 30, 2, 45) },
            { "C", new Item("C", 20, null, null) },
            { "D", new Item("D", 15, null, null) }
        };

        public Item? GetItem(string item)
        {
            if (_itemRepository.ContainsKey(item))
            {
                return _itemRepository[item];
            }
            return null;
        }
    }
}
