using System;

namespace Kata
{
    public class Checkout : ICheckout
    {
        public int GetTotalPrice()
        {
            return 0;
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
