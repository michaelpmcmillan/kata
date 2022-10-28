using CheckoutKata.Item;

namespace CheckoutKata.Printing
{
    public interface ICheckoutMessagePrinter
    {
        void PrintWelcomeMessage();
        void PrintTotalPrice(decimal totalPrice);
        void PrintItemPrice(ICheckoutItem item);
    }
}
