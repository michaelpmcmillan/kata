﻿namespace Kata
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
