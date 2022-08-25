using CheckoutKata.Item;
using CheckoutKata.Resources;

namespace CheckoutKata.Printing
{
    public class CheckoutMessagePrinter : ICheckoutMessagePrinter
    {
        private readonly IMessagePrinter _messagePrinter;

        public CheckoutMessagePrinter(IMessagePrinter messagePrinter)
        {
            _messagePrinter = messagePrinter;
        }

        public void PrintWelcomeMessage()
        {
            _messagePrinter.Print(Strings.WelcomeMessage);
        }

        public void PrintTotalPrice(decimal totalPrice)
        {
            _messagePrinter.Print(string.Format(Strings.TotalPriceMessage, totalPrice));
        }

        public void PrintItemPrice(ICheckoutItem item)
        {
            _messagePrinter.Print(string.Format(Strings.ItemPriceMessage, item.ItemCode, item.ItemPrice.ToString("0.00")));
        }
    }
}
