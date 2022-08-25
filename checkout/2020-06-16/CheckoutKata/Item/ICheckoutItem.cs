namespace CheckoutKata.Item
{
    public interface ICheckoutItem
    {
        char ItemCode { get; }
        decimal ItemPrice { get; }
    }
}