using VendingMachineKata.CoinRegister;

namespace VendingMachineKata.Display
{
    public interface IVendingMachineDisplay
    {
        string Display { get; }
        void Update(ICoinCollection coinCollection);
    }
}
