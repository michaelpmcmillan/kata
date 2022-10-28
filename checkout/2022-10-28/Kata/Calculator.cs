namespace Kata
{
    public class Calculator : ICalculator
    {
        private readonly IItemRespository _itemRepository;

        public Calculator(IItemRespository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public int GetPrice(Dictionary<string, int> scannedItems)
        {
            int total = 0;
            foreach (var scannedItem in scannedItems)
            {
                var item = _itemRepository.GetItem(scannedItem.Key);
                if (item != null)
                {
                    if (item.DiscountPrice != null && item.DiscountQty != null)
                    {
                        var completeDiscountSets = scannedItem.Value / item.DiscountQty.Value;
                        total += completeDiscountSets * item.DiscountPrice.Value;
                        var partialDiscountSets = scannedItem.Value % item.DiscountQty.Value;
                        total += partialDiscountSets * item.FullPrice;
                    }
                    else
                    {
                        total += scannedItem.Value * item.FullPrice;
                    }
                }
            }
            return total;
        }
    }
}
