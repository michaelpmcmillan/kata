namespace CheckoutKata20200616
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = IoC.Configure();
            var app = (IConsoleApplication)serviceProvider.GetService(typeof(IConsoleApplication));
            app.EnterLoop();
        }
    }
}
