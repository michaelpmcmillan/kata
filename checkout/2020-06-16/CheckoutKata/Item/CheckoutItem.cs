namespace CheckoutKata.Item
{
    public class CheckoutItem : ICheckoutItem
    {
        public char ItemCode { get; }
        public decimal ItemPrice { get; }

        public CheckoutItem(char itemCode, decimal itemPrice)
        {
            ItemCode = itemCode;
            ItemPrice = itemPrice;
        }
    }
}