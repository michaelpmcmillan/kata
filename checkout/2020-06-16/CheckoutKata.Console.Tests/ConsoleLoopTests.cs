using AutoFixture;
using CheckoutKata.Scanning;
using CheckoutKata20200616;
using Moq.AutoMock;
using Xunit;

namespace CheckoutKata.Console.Tests
{
    public class ConsoleLoopTests
    {
        private Fixture Fixture { get; }
        private AutoMocker Mocker { get; }

        public ConsoleLoopTests()
        {
            Mocker = new AutoMocker();
            Fixture = new Fixture();
        }

        [Fact]
        public void WhenKeyIsPressed_ThenCheckoutScanIsInvoked()
        {
            var application = Mocker.CreateInstance<ConsoleApplication>();

            Mocker.GetMock<IItemScanner>().Setup(scanner => scanner.Scan()).Returns('A');

            //application.EnterLoop();


            // test that for each console key press, ICheckout.Scan is invoked with the given key
        }
    }

    
}
