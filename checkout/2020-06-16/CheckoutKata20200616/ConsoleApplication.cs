using CheckoutKata;
using CheckoutKata.Printing;
using CheckoutKata.Scanning;

namespace CheckoutKata20200616
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly ICheckout _checkout;
        private readonly IItemScanner _itemScanner;
        private readonly ICheckoutMessagePrinter _checkoutMessagePrinter;

        public ConsoleApplication(ICheckout checkout, IItemScanner itemScanner, ICheckoutMessagePrinter checkoutMessagePrinter)
        {
            _checkout = checkout;
            _itemScanner = itemScanner;
            _checkoutMessagePrinter = checkoutMessagePrinter;
        }

        public void EnterLoop()
        {
            _checkoutMessagePrinter.PrintWelcomeMessage();

            do
            {
                var itemCode = _itemScanner.Scan();

                if (itemCode == 'X')
                    break;

                _checkout.AppendItem(itemCode);

            } while (true);

            _checkoutMessagePrinter.PrintTotalPrice(_checkout.GetTotalPrice());
        }
    }
}
