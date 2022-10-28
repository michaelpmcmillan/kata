namespace Kata
{
    public interface ICheckout
    {
        int GetTotal();

        void Scan(string item);
    }
}